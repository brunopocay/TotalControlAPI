using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Services.ControleMensalService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistroFinanceiroMensalController : ControllerBase
    {
        private readonly IRegistroFinanceiroMensalService _registroMensal;

        public RegistroFinanceiroMensalController(IRegistroFinanceiroMensalService control)
        {
			_registroMensal = control;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadRegistroFinanceiroMensalDTO>>> GetBills()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _registroMensal.GetBills(userEmail);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReadRegistroFinanceiroMensalDTO>> NewBill(CreateRegistroFinanceiroMensalDTO conta)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            try
            {
                var result = await _registroMensal.NewBill(conta, userEmail);
                return Ok(result);
            }
            catch (DbUpdateException dbError)
            {
                return StatusCode(500, $"Erro interno do banco de dados: {dbError}");
            }
            catch (Exception error )
            {
                return NotFound(error.Message);
            }
           
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteBill(DeleteRegistroFinanceiroMensalDTO conta)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            try
            {
                await _registroMensal.DeleteBill(conta, userEmail);
                return Ok(new {message = "Registro excluído com sucesso." });
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest($"Erro interno de servidor: {dbError.Message}");
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ReadRegistroFinanceiroMensalDTO>> UpdateBill(UpdateRegistroFinanceiroMensalDTO conta)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            try
            {
                await _registroMensal.UpdateBill(conta, userEmail);
                return Ok(conta);
            }
            catch (DbUpdateException dbError)
            {
                return StatusCode(500, $"Erro interno de servidor: {dbError}");
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
