using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class ProductoraService
{
    private readonly ApplicationContext _dbContext;

    public ProductoraService(ApplicationContext applicationContext)
    {
        _dbContext = applicationContext;
    }

    #region Metodos generales para las productoras

        // Metodo para agregar una nueva productora
        public async Task Add(CreateProductoraViewModel vm)
        {
            var productora = new Productora
            {
                Nombre = vm.Nombre,
                Descripcion = vm.Descripcion
            };
            _dbContext.Productoras.Add(productora);
            await _dbContext.SaveChangesAsync();
        }


        // Metodo para ver todos las productoras
        public async Task<List<ProducturaViewModel>> GetAll()
        {
            var productora = await _dbContext.Productoras.ToListAsync();
            return productora.Select(productora => new ProducturaViewModel
            {
                Id = productora.Id,
                Nombre = productora.Nombre,
                Descripcion = productora.Descripcion
            }).ToList();
        }


        // Metodo para ver una productora por su id
        public async Task<CreateProductoraViewModel> GetById(int id)
        {
            var productora = await _dbContext.Productoras.FirstOrDefaultAsync(p => p.Id == id);
            CreateProductoraViewModel vm = new();
            vm.Id = productora.Id;
            vm.Nombre = productora.Nombre;
            vm.Descripcion = productora.Descripcion;
            return vm;
        }


        // Metodo para actualizar una productora
        public async Task Update(CreateProductoraViewModel vm)
        {
            var productora = await _dbContext.Productoras.FirstOrDefaultAsync(p => p.Id == vm.Id);
            productora.Nombre = vm.Nombre;
            productora.Descripcion = vm.Descripcion ?? productora.Descripcion;
            _dbContext.Update(productora);
            await _dbContext.SaveChangesAsync();
        }


        // Metodo para eliminar una productora
        public async Task Delete(int id)
        {
            var productora = await _dbContext.Productoras.FirstOrDefaultAsync(p => p.Id == id);
            _dbContext.Productoras.Remove(productora);
            await _dbContext.SaveChangesAsync();
        }

    #endregion
}