using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Categorias> UpdateCategoria(nCategoryDTO category, string userEmail);
        Task<Categorias> DeleteCategory(nCategoryDTO category, string userEmail);
        Task<Categorias> newCategory(nCategoryDTO category, string userEmail);
        Task<Categorias> GetCategory();
    }
}
