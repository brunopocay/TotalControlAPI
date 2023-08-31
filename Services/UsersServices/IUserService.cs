using System.Security.Claims;

namespace TotalControlAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<Users> Register(UserRegisterDTO pessoa);
        public List<string> GetMyData();
    }
}
