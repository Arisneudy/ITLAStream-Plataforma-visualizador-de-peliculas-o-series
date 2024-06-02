using ITLAStream.Core.Application.ViewModels;
using ITLAStream.Infrastucture.Persistence.Contexts;
using ITLAStream.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ITLAStream.Core.Application.Interfaces.Repositories;

namespace ITLAStream.Infrastucture.Persistence.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly ApplicationContext _dbContext;

        public SerieRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Series serie)
        {
            _dbContext.Series.Add(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Series>> GetAll()
        {
            return await _dbContext.Series
                .Include(s => s.Productora)
                .Include(s => s.Genero)
                .ToListAsync();
        }

        public async Task<Series> GetById(int id)
        {
            return await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Series>> GetByName(string nombre)
        {
            return await _dbContext.Series
                .Include(s => s.Productora)
                .Include(s => s.Genero)
                .Where(s => s.Nombre.StartsWith(nombre) || s.Nombre.Contains(nombre))
                .ToListAsync();
        }

        public async Task Update(Series serie)
        {
            _dbContext.Series.Update(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == id);
            if (serie != null)
            {
                _dbContext.Series.Remove(serie);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Series>> GetAllFilters(FiltroViewModel vm)
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

            return await query.ToListAsync();
        }
    }
}
