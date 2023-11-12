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
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryService _category;
        public CategoryController(ICategoryService category)
        {           
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categorias>>> GetCategories()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _category.GetCategory(userEmail);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> NewCategory(CategoryDTO category)
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
                return StatusCode(404, error.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Categorias>> DeleteCategory(CategoryDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {               
                var result = await _category.DeleteCategory(category, userEmail!);
                return Ok(result);
            }
            catch ( DbUpdateException dbError )
            {            
                return StatusCode(500, $"Erro interno do banco de dados : {dbError.Message}");
            }
            catch ( Exception error )
            {            
                return StatusCode(404, error.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Categorias>> UpdateCategory(CategoryDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {          
                var result = await _category.UpdateCategoria(category, userEmail!);
                return Ok(result);  
            }
            catch ( DbUpdateException dbError )
            {
                return StatusCode(500, $"Erro interno do banco de dados : {dbError.Message}");
            }
            catch (Exception error)
            {
                return StatusCode(404, error.Message);
            }
        }

    }
}
