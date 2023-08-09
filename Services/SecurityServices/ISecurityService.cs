namespace TotalControlAPI.Services.SecurityServices
{
    public interface ISecurityService
    {
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
        public RefreshToken GenerateRefreshToken(Users user);
        public Users SetRefreshToken(Users user, RefreshToken newRefreshToken, HttpResponse response);
        public string CreateToken(Users user);
    }
}
