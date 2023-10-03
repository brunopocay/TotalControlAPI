using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Services.MesControleService;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MesController : ControllerBase
    {
        private readonly IMesControleService _mesControleService;
        public MesController(IMesControleService mes)
        {
            _mesControleService = mes;        
        }

        [HttpPost]
        public async Task <ActionResult<MesControle>> newMonth(MesControleDTO mes)
        {
            var user = User.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _mesControleService.NewMonth(mes, user);
            return Ok(result);
        }
    }
}
