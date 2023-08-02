namespace TotalControlAPI.Services.SecurityServices
{
    public interface ISecurityService
    {
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
        public string CreateToken(Users user);
    }
}
