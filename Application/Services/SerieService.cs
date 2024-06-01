using ITLAStream.Core.Domain.Entities;
using Database.Models;
using ITLAStream.Core.Application.ViewModels;
using ITLAStream.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITLAStream.Core.Application.Services;

public class SerieService
{
    private readonly ISerieRepository _serieRepository;

    public SerieService(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    #region Metodos generales para las series

    public async Task Add(CreateSerieViewModel vm)
    {
        var serie = new Series
        {
            Id = vm.Id,
            Nombre = vm.Nombre,
            Descripcion = vm.Descripcion,
            Portada = vm.Portada,
            VideoLink = vm.VideoLink,
            ProductoraId = vm.ProductoraId,
            GeneroId = vm.GeneroId,
        };
        await _serieRepository.Add(serie);
    }

    public async Task<List<SerieViewModel>> GetAll()
    {
        var series = await _serieRepository.GetAll();

        return series.Select(serie => new SerieViewModel
        {
            Id = serie.Id,
            Nombre = serie.Nombre,
            Descripcion = serie.Descripcion,
            Portada = serie.Portada,
            VideoLink = serie.VideoLink,
            ProductoraId = serie.ProductoraId,
            GeneroId = serie.GeneroId,
            Genero = serie.Genero,
            Productora = serie.Productora
        }).ToList();
    }

    public async Task<CreateSerieViewModel> GetById(int id)
    {
        var serie = await _serieRepository.GetById(id);

        if (serie == null) return null;

        return new CreateSerieViewModel
        {
            Id = serie.Id,
            Nombre = serie.Nombre,
            Descripcion = serie.Descripcion,
            Portada = serie.Portada,
            VideoLink = serie.VideoLink,
            ProductoraId = serie.ProductoraId,
            GeneroId = serie.GeneroId
        };
    }

    public async Task<List<SerieViewModel>> GetByName(string nombre)
    {
        var series = await _serieRepository.GetByName(nombre);

        return series.Select(s => new SerieViewModel
        {
            Id = s.Id,
            Nombre = s.Nombre,
            Descripcion = s.Descripcion,
            Portada = s.Portada,
            VideoLink = s.VideoLink,
            ProductoraId = s.ProductoraId,
            GeneroId = s.GeneroId,
            Genero = s.Genero,
            Productora = s.Productora
        }).ToList();
    }

    public async Task Update(CreateSerieViewModel vm)
    {
        var serie = await _serieRepository.GetById(vm.Id);

        if (serie == null) return;

        serie.Nombre = vm.Nombre;
        serie.Descripcion = vm.Descripcion;
        serie.Portada = vm.Portada;
        serie.VideoLink = vm.VideoLink;
        serie.ProductoraId = vm.ProductoraId;
        serie.GeneroId = vm.GeneroId;

        await _serieRepository.Update(serie);
    }

    public async Task Delete(int id)
    {
        await _serieRepository.Delete(id);
    }


    #endregion

    #region Metodo para obtener todos los filtros de las series

    public async Task<List<SerieViewModel>> GetAllFilters(FiltroViewModel vm)
    {
        var series = await _serieRepository.GetAllFilters(vm);

        return series.Select(s => new SerieViewModel
        {
            Id = s.Id,
            Nombre = s.Nombre,
            Descripcion = s.Descripcion,
            Portada = s.Portada,
            VideoLink = s.VideoLink,
            ProductoraId = s.ProductoraId,
            GeneroId = s.GeneroId,
            Genero = s.Genero,
            Productora = s.Productora
        }).ToList();
    }

    #endregion

}