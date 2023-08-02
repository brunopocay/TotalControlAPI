using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TotalControlAPI.Services.SecurityServices;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ISecurityService _securityService;
        private readonly DataContext _dataContext;
        
        public AuthController(DataContext context, ISecurityService securityService)
        {
            _dataContext = context;     
            _securityService = securityService;
        }

        [HttpPost("login")]
        public ActionResult<Users> login(UserRequestDTO request)
        {

            var user = _dataContext.Users.SingleOrDefault(u => u.Email == request.Email);

            if(user is null)
            {
                return BadRequest("Usuario não encontrado ou senha incorreta.");
            }

            if(!_securityService.VerifyPasswordHash(request.Senha, user.PasswordHash, user.PasswordSalt))
            {                                
                return BadRequest("Usuario não encontrado ou senha incorreta.");
            }

            string token = _securityService.CreateToken(user);
            return Ok(token);
        }

        
    }
}
