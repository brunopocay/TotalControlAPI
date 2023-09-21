using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Services.ControleMensalService;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControleMensalController : ControllerBase
    {
        private readonly IControleMensalService _control;

        public ControleMensalController(IControleMensalService control)
        {
            _control = control;
        }

        [HttpPost]
        public async Task<ActionResult<List<ControleMensal>>> newBill(List<ControleMensalDTO> conta)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            try
            {
                var result = await _control.newBill(conta, userEmail);
                return Ok(result);
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest($"Erro interno do banco de dados: {dbError.Message}");
            }
            catch (Exception error )
            {
                return NotFound(error.Message);
            }
           
        }
    }
}
