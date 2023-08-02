using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TotalControlAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserService(IMapper mapper,DataContext context)
        {
            _context = context;
            _mapper = mapper;
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
