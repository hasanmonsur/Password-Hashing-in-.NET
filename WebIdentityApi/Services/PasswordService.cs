using WebIdentityApi.Contacts;

namespace WebIdentityApi.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            // Hash the password with a generated salt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
