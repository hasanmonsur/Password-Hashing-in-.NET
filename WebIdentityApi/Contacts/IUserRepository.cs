namespace WebIdentityApi.Contacts
{
    public interface IUserRepository
    {
        void CreateUser(string username, string password);
        string  ValidateUser(string username);
    }
}