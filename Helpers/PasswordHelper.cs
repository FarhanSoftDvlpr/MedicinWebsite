using Microsoft.AspNetCore.Identity;

namespace MEDICINE.WEB.Helpers
{
    public class PasswordHelper
    {
        private readonly PasswordHasher<string> _passwordHasher;

        public PasswordHelper()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(
                null,
                hashedPassword,
                providedPassword
            );

            return result == PasswordVerificationResult.Success;
        }
    }
}