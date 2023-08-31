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

        public List<string> GetMyData()
        {
            var result = new List<string>();
     
            if ( _contextAccessor !=  null )
            {             
                var claims = _contextAccessor.HttpContext!.User.Claims;
           
                foreach ( var claim in claims )
                {
                    result.Add(claim.Value);
                }              
            }        
            return result;
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
