using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private IUserService _userService;
        private ISecurityService _securityService;

        public UsersController(DataContext context,IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(UserRegisterDTO user)
        {
            _securityService.CreatePasswordHash(user.Senha, out string passwordHash, out string passwordSalt);     
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var userAlreadyExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);       
            
            if(userAlreadyExists != null)
            {
                return BadRequest("Usuário já cadastrado.");
            }

            var result = await _userService.Register(user);
            return Ok(result);
        }

        
    }
}
