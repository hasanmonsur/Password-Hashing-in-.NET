using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;
using WebIdentityApi.Contacts;

namespace WebIdentityApi.Services
{
    public class IdentityPasswordService : IIdentityPasswordService
    {
        public string HashPassword(string password)
        {
            var hasher = new PasswordHasher<string>();
            string hashedPassword = hasher.HashPassword(password, "MySecurePassword");

            return hashedPassword;
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var hasher = new PasswordHasher<string>();
            var result = hasher.VerifyHashedPassword(enteredPassword, storedHash, "MySecurePassword");

            if (result == PasswordVerificationResult.Success)
                return true;
            else return false;
        }
    }
}
