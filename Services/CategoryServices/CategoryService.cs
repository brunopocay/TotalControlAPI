using AutoMapper;
using System.Security.Claims;
using TotalControlAPI.Data;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Models;

namespace TotalControlAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        public Task<Categorias> GetCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<Categorias> newCategory(nCategoryDTO category, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var categoryAlreadyExists = _context.Categorias.FirstOrDefault(c =>
                c.User!.Email == userEmail &&
                c.NomeCategoria == category.NomeCategoria
            );

            if ( categoryAlreadyExists != null )            
                throw new InvalidOperationException("Essa categoria já esta sendo utilizada. Cadastre uma categoria com nome diferente.");
            
            var newCategory = new Categorias
            {
                UserId = user!.Id,
                NomeCategoria = category.NomeCategoria,
                TipoCategorias = category.TipoCategorias
            };
         
            var result = _mapper.Map<Categorias>(newCategory);
            _context.Categorias.Add(newCategory);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Categorias> DeleteCategory(nCategoryDTO category, string userEmail)
        {

            var categoryDelete = _context.Categorias.FirstOrDefault(cd =>
                cd.User!.Email == userEmail &&
                cd.NomeCategoria == category.NomeCategoria
            ) ?? throw new InvalidOperationException("Essa categoria não existe ou já foi apagada");

            _context.Categorias.Remove(categoryDelete!);
            await _context.SaveChangesAsync();
            return categoryDelete;
        }

        public async Task<Categorias> UpdateCategoria(nCategoryDTO category, string userEmail)
        {
            var updateCategory = _context.Categorias.FirstOrDefault(cd => 
                cd.User!.Email == userEmail &&  
                cd.Id == category.IdCategoria
            ) ?? throw new InvalidOperationException("Categoria não encontrada.");

            updateCategory.NomeCategoria = category.NomeCategoria;
            updateCategory.TipoCategorias = category.TipoCategorias;

            _context.Categorias.Update(updateCategory!);
            await _context.SaveChangesAsync();
            return updateCategory;
        }
    }
}
