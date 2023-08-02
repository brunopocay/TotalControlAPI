namespace TotalControlAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<Users> Register(UserRegisterDTO pessoa);
        
    }
}
