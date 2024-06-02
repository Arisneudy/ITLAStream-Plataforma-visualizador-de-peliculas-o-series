using ITLAStream.Core.Application.Interfaces.Services;
using ITLAStream.Core.Application.ViewModels;
using ITLAStream.Core.Domain.Entities;
using ITLAStream.Core.Domain.Interfaces.Repositories;

namespace ITLAStream.Core.Application.Services;

public class GeneroService : IGeneroService
{

    private readonly IGeneroRepository _generoRepository;

    public GeneroService(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    #region Metodos generales para los generos

    public async Task Add(CreateGeneroViewModel vm)
    {
        var genero = new Genero
        {
            Nombre = vm.Nombre,
            Descripcion = vm.Descripcion
        };
        await _generoRepository.Add(genero);
    }

    public async Task<List<GeneroViewModel>> GetAll()
    {
        var generos = await _generoRepository.GetAll();

        return generos.Select(genero => new GeneroViewModel
        {
            Id = genero.Id,
            Nombre = genero.Nombre,
            Descripcion = genero.Descripcion
        }).ToList();
    }

    public async Task<CreateGeneroViewModel> GetById(int id)
    {
        var genero = await _generoRepository.GetById(id);

        if (genero == null) return null;

        return new CreateGeneroViewModel
        {
            Id = genero.Id,
            Nombre = genero.Nombre,
            Descripcion = genero.Descripcion
        };
    }

    public async Task Update(CreateGeneroViewModel vm)
    {
        var genero = await _generoRepository.GetById(vm.Id);

        if (genero == null) return;

        genero.Nombre = vm.Nombre;
        genero.Descripcion = vm.Descripcion ?? genero.Descripcion;

        await _generoRepository.Update(genero);
    }

    public async Task Delete(int id)
    {
        await _generoRepository.Delete(id);
    }

    #endregion
}