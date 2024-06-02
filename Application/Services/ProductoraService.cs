using ITLAStream.Core.Application.Interfaces.Services;
using ITLAStream.Core.Application.ViewModels;
using ITLAStream.Core.Domain.Entities;
using ITLAStream.Core.Domain.Interfaces.Repositories;

namespace ITLAStream.Core.Application.Services;

public class ProductoraService : IProductoraService
{
    private readonly IProductoraRepository _productoraRepository;

    public ProductoraService(IProductoraRepository productoraRepository)
    {
        _productoraRepository = productoraRepository;
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
        await _productoraRepository.Add(productora);
    }


    // Metodo para ver todos las productoras
    public async Task<List<ProducturaViewModel>> GetAll()
    {
        var productora = await _productoraRepository.GetAll();
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
        var productora = await _productoraRepository.GetById(id);
        CreateProductoraViewModel vm = new();
        vm.Id = productora.Id;
        vm.Nombre = productora.Nombre;
        vm.Descripcion = productora.Descripcion;
        return vm;
    }


    // Metodo para actualizar una productora
    public async Task Update(CreateProductoraViewModel vm)
    {
        var productora = await _productoraRepository.GetById(vm.Id);
        productora.Nombre = vm.Nombre;
        productora.Descripcion = vm.Descripcion ?? productora.Descripcion;
        await _productoraRepository.Update(productora);
    }


    // Metodo para eliminar una productora
    public async Task Delete(int id)
    {
        var productora = await _productoraRepository.GetById(id);
        await _productoraRepository.Delete(id);
    }

    #endregion
}