using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Categorias> UpdateCategoria(CategoryDTO category, string userEmail);
        Task<Categorias> DeleteCategory(CategoryDTO category, string userEmail);
        Task<Categorias> NewCategory(CategoryDTO category, string userEmail);
        Task<List<Categorias>> GetCategory(string userEmail);
    }
}
