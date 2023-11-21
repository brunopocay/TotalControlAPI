using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.CategoryServices
{
    public interface ICategoriaService
    {
        Task<ReadCategoriaDTO> UpdateCategoria(UpdateCategoriaDTO category, string userEmail);
        Task<ReadCategoriaDTO> DeleteCategory(DeleteCategoriaDTO category, string userEmail);
        Task<ReadCategoriaDTO> NewCategory(CreateCategoriaDTO category, string userEmail);
        Task<List<ReadCategoriaDTO>> GetCategory(string userEmail);
    }
}
