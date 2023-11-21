using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Models;
using TotalControlAPI.Services.CategoryServices;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        
        private readonly ICategoriaService _category;
        public CategoriaController(ICategoriaService category)
        {           
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadCategoriaDTO>>> GetCategories()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _category.GetCategory(userEmail);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCategoriaDTO>> NewCategory(CreateCategoriaDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {
                var result = await _category.NewCategory(category, userEmail!);
                return Ok(result);
            }
            catch ( DbUpdateException dbError )
            {
                return StatusCode(500, $"Erro interno do banco de dados : {dbError.Message}");
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoriaDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {               
                var result = await _category.DeleteCategory(category, userEmail!);
                return Ok(new { message = "Excluido com sucesso" });
            }
            catch ( DbUpdateException dbError )
            {            
                return StatusCode(500, $"Erro interno do banco de dados : {dbError.Message}");
            }
            catch ( Exception error )
            {            
                return NotFound(error.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCategoriaDTO>> UpdateCategory(UpdateCategoriaDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {          
                var result = await _category.UpdateCategoria(category, userEmail!);
                return Ok(result);  
            }
            catch ( DbUpdateException dbError )
            {
                return StatusCode(500, $"Erro interno do banco de dados : {dbError}" );
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

    }
}
