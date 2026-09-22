using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Security;
using BankingSystem.Application.Common.Errors;
using BankingSystem.Application.Common.Results;
using BankingSystem.Application.Services.Auth.Dtos;
using BankingSystem.Domain.Common;
using BankingSystem.Domain.Entities;
using FluentValidation;

namespace BankingSystem.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private static readonly Guid CustomerRoleId = Guid.Parse(DefaultRoles.Customer.Id);
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<RegisterRequest> _registerValidator;
        public AuthService(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IValidator<RegisterRequest> registerValidator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _registerValidator = registerValidator;
        }
        public async Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            // 1. Validate the request.
            var validation = await _registerValidator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result.Failure<RegisterResponse>(validation.ToErrors());

            // 2. Build the user first, so the email is normalized in one place (User.SetEmail).
            var user = new User
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Phone = request.PhoneNumber.Trim(),
                RoleId = CustomerRoleId,
                IsActive = false,          // Stays false until the email is confirmed.
                AccessFailedCount = 0
            };
            user.SetEmail(request.Email);

            // 3. Check the email is not taken. Done before hashing, because BCrypt is slow on purpose.
            if (await _userRepository.EmailExistsAsync(user.NormalizedEmail, cancellationToken))
                return UserErrors.EmailAlreadyRegistered;

            // 4. Hash the password.
            user.PasswordHash = _passwordHasher.Hash(request.Password);

            // 5. Save through the unit of work.
            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // make the background job to send the email confirmation link

            return new RegisterResponse(user.Id, user.Email);
        }
    }
}
