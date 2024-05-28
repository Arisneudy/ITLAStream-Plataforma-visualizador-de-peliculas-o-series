using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SerieService
{
    private readonly ApplicationContext _dbContext;

    public SerieService(ApplicationContext applicationContext)
    {
        _dbContext = applicationContext;
    }

    #region Metodos generales para las series

        // Metodo para agregar un nueva serie
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
            _dbContext.Series.Add(serie);
            await _dbContext.SaveChangesAsync();
        }

        // Metodo para ver todas los series
        public async Task<List<SerieViewModel>> GetAll()
        {
            var serie = await _dbContext.Series
                .Include(s => s.Productora)
                .Include(s => s.Genero)
                .ToListAsync();

            return serie.Select(serie => new SerieViewModel
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

        // Metodo para ver una serie por su id
        public async Task<CreateSerieViewModel> GetById(int id)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == id);
            CreateSerieViewModel vm = new();
            vm.Id = serie.Id;
            vm.Nombre = serie.Nombre;
            vm.Descripcion = serie.Descripcion;
            vm.Portada = serie.Portada;
            vm.VideoLink = serie.VideoLink;
            vm.ProductoraId = serie.ProductoraId;
            vm.GeneroId = serie.GeneroId;
            return vm;
        }

        // Metodo para buscar una serie por su nombre
        public async Task<List<SerieViewModel>> GetByName(string nombre)
        {
            var seriesList = await _dbContext.Series
                    .Include(s => s.Productora)
                    .Include(s => s.Genero)
                    .ToListAsync();

            var serie = seriesList.Select(s => new SerieViewModel
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

            if (nombre != null)
            {
                serie = serie.Where(s => s.Nombre.StartsWith(nombre) || s.Nombre.Contains(nombre)).ToList();
            }


            return serie.ToList();
        }

        // Metodo para actualizar una serie
        public async Task Update(CreateSerieViewModel vm)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == vm.Id);
            serie.Nombre = vm.Nombre;
            serie.Descripcion = vm.Descripcion;
            serie.Portada = vm.Portada;
            serie.VideoLink = vm.VideoLink;
            serie.ProductoraId = vm.ProductoraId;
            serie.GeneroId = vm.GeneroId;
            _dbContext.Update(serie);
            await _dbContext.SaveChangesAsync();
        }


        // Metodo para eliminar una serie
        public async Task Delete(int id)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == id);
            _dbContext.Series.Remove(serie);
            await _dbContext.SaveChangesAsync();
        }

    #endregion

    #region Metodo para obtener todos los filtros de las series

        public async Task<List<SerieViewModel>> GetAllFilters(FiltroViewModel vm)
    {
        IQueryable<Series> query = _dbContext.Series
            .Include(s => s.Productora)
            .Include(s => s.Genero);

        if (vm.GeneroId != 0)
        {
            query = query.Where(s => s.GeneroId == vm.GeneroId);
        }

        if (vm.ProductoraId != 0)
        {
            query = query.Where(s => s.ProductoraId == vm.ProductoraId);
        }

        var series = await query.ToListAsync();

        var seriesViewModel = series.Select(s => new SerieViewModel
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

        return seriesViewModel;
    }

    #endregion

}