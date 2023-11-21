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
    public class MesReferenciaController : ControllerBase
    {
        private readonly IMesReferenciaService _mesReferenciaService;
        public MesReferenciaController(IMesReferenciaService mesReferencia)
        {
			_mesReferenciaService = mesReferencia;        
        }

        [HttpGet]
        public async Task<ActionResult<ReadMesReferenciaDTO>> GetMonth()
        {
            var user = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _mesReferenciaService.GetMonthReference(user);

            return Ok(result);      
        }

        [HttpPost]
        public async Task<ActionResult<ReadMesReferenciaDTO>> NewMonth(CreateMesReferenciaDTO mes)
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.Email)!.Value;

                var result = await _mesReferenciaService.NewMonthReference(mes, user);
                return Ok(result);
            }
            catch(InvalidOperationException error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ReadMesReferenciaDTO>> UpdateMonth(UpdateMesReferenciaDTO mes)
        {
            var user = User.FindFirst(ClaimTypes.Email)!.Value;

			var result = await _mesReferenciaService.UpdateMonthReference(mes, user);
            return Ok(result);
        }
        
    }
}
