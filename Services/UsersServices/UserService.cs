using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace TotalControlAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IMapper mapper,DataContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper; 
            _contextAccessor = contextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if ( _contextAccessor != null )
                result = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name);

            return result!;
        }

        public async Task<Users> Register(UserRegisterDTO newUser)
        {
            var user = _mapper.Map<Users>(newUser);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        
    }
}
