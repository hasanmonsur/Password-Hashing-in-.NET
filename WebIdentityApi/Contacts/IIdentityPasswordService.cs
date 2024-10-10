namespace WebIdentityApi.Contacts
{
    public interface IIdentityPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}