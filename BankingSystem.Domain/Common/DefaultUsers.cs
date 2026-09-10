namespace BankingSystem.Domain.Common
{
    public static class DefaultUsers
    {
        public static class Admin
        {
            public const string Id = "d98d583d-71cf-4a5b-8c97-0f875db2b473";          
            public const string FirstName = "Shenoda";
            public const string LastName = "Adel";
            public const string Email = "admin@bankingsystem.com";
            public static readonly string NormalizedEmail = Email.ToLowerInvariant();

            public const string PasswordHash = "$2a$11$Otfz4kJcr1dJTKjYOg9h.e2ueIZ55BMWfqyPbe5TRFh7BKoD1ocqm";

            public const string Phone = "01092064015";
            public const string RoleId = DefaultRoles.Admin.Id;

            public const bool IsActive = true;

            public const int AccessFailedCount = 0;
        }
    }
}
