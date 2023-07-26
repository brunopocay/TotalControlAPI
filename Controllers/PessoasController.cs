using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.Data;
using TotalControlAPI.Models;
using TotalControlAPI.Services.PessoaServices;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        private IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoas>> Register(Pessoas pessoa)
        {
            var result = await _pessoaService.Register(pessoa);
            return Ok(result);
        }
    }
}
