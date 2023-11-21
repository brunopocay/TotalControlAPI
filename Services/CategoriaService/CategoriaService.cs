using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TotalControlAPI.Data;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Models;

namespace TotalControlAPI.Services.CategoryServices
{
    public class CategoriaService : ICategoriaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoriaService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReadCategoriaDTO>> GetCategory(string userEmail)
        {
            var user = await _context.Categorias.Where(u => u.User!.Email == userEmail).ToListAsync();

            if (user is null)           
                throw new InvalidOperationException("Usuário não encontrado");

            var result = new List<ReadCategoriaDTO>();
            foreach (var categoria in user)
            {
                var resultMapped = _mapper.Map<ReadCategoriaDTO>(categoria);
                result.Add(resultMapped);
            }

            return result;
        }

        public async Task<ReadCategoriaDTO> NewCategory(CreateCategoriaDTO category, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var categoryAlreadyExists = _context.Categorias.FirstOrDefault(categoria =>
                categoria.User!.Email == userEmail &&
                categoria.NomeCategoria == category.NomeCategoria
            );

            if ( categoryAlreadyExists != null )            
                throw new InvalidOperationException("Essa categoria já esta sendo utilizada. Cadastre uma categoria com nome diferente.");
   
            var result = _mapper.Map<Categorias>(category);
            result.UserId = user!.Id;
            _context.Categorias.Add(result);
            await _context.SaveChangesAsync();

            var resultdto = _mapper.Map<ReadCategoriaDTO>(result);
            return resultdto;
        }

        public async Task<ReadCategoriaDTO> DeleteCategory(DeleteCategoriaDTO category, string userEmail)
        {
            var categoryDelete = _context.Categorias.FirstOrDefault(categoria =>
                categoria.User!.Email == userEmail &&
                categoria.Id == category.IdCategoria
            ) ?? throw new InvalidOperationException("Essa categoria não existe ou já foi apagada");

            _context.Categorias.Remove(categoryDelete);
            await _context.SaveChangesAsync();

            var resultdto = _mapper.Map<ReadCategoriaDTO>(categoryDelete);
            return resultdto;
        }

        public async Task<ReadCategoriaDTO> UpdateCategoria(UpdateCategoriaDTO category, string userEmail)
        {
            var updateCategory = _context.Categorias.FirstOrDefault(categoria =>
                categoria.User!.Email == userEmail &&
                categoria.Id == category.CategoriaId
			) ?? throw new InvalidOperationException("Categoria não encontrada.");

			updateCategory.NomeCategoria = category.NomeCategoria;
            updateCategory.TipoCategorias = category.TipoCategorias ?? updateCategory.TipoCategorias;

            await _context.SaveChangesAsync();

            var resultdto = _mapper.Map<ReadCategoriaDTO>(updateCategory);
            return resultdto;
        }
       
    }
}
