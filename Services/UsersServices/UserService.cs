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
        private readonly ISecurityService _securityService;
        public UserService(IMapper mapper,DataContext context, IHttpContextAccessor contextAccessor, ISecurityService security)
        {
            _context = context;
            _mapper = mapper; 
            _contextAccessor = contextAccessor;
            _securityService = security;
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

            _securityService.CreatePasswordHash(user.Senha, out string passwordHash, out string passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        
    }
}
