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
        private readonly DataContext _dataContext;
        private readonly ICategoryService _category;
        public CategoryController(DataContext context, ICategoryService category)
        {
            _dataContext = context;
            _category = category;
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> newCategory(nCategoryDTO category)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {
                var result = await _category.newCategory(category, userEmail!);
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
        public async Task<ActionResult<Categorias>> DeleteCategory(nCategoryDTO category)
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
        public async Task<ActionResult<Categorias>> UpdateCategory(nCategoryDTO category)
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
