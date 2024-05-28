using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class GeneroService
{
    
    private readonly ApplicationContext _dbContext;
    
    public GeneroService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Metodos generales para los generos
    
        // Metodo para agregar un nuevo genero
        public async Task Add(CreateGeneroViewModel vm)
        {
            var genero = new Genero
            {
                Nombre = vm.Nombre
            };
            _dbContext.Generos.Add(genero);
            await _dbContext.SaveChangesAsync();
        }
        
        
        // Metodo para ver todos los generos
        public async Task<List<GeneroViewModel>> GetAll()
        {
            var genero = await _dbContext.Generos.ToListAsync();
            return genero.Select(genero => new GeneroViewModel
            {
                Id = genero.Id,
                Nombre = genero.Nombre,
                Descripcion = genero.Descripcion
            }).ToList();
        }
        
        
        // Metodo para ver un genero por su id
        public async Task<CreateGeneroViewModel> GetById(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
            CreateGeneroViewModel vm = new();
            vm.Id = genero.Id;
            vm.Nombre = genero.Nombre;
            vm.Descripcion = genero.Descripcion;
            return vm;
        }
        
        
        // Metodo para actualizar un genero
        public async Task Update(CreateGeneroViewModel vm)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == vm.Id);
            genero.Nombre = vm.Nombre;
            genero.Descripcion = vm.Descripcion ?? genero.Descripcion;
            _dbContext.Update(genero);
            await _dbContext.SaveChangesAsync();
        }
        
        
        // Metodo para eliminar un genero
        public async Task Delete(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.Generos.Remove(genero);
            await _dbContext.SaveChangesAsync();
        }

    #endregion
}