using Microsoft.AspNetCore.Mvc;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;
        private ISecurityService _securityService;

        public UsersController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(UserRegisterDTO user)
        {
            _securityService.CreatePasswordHash(user.Senha, out string passwordHash, out string passwordSalt);     
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var result = await _userService.Register(user);
            return Ok(result);
        }

        
    }
}
