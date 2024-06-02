using ITLAStream.Core.Domain.Entities;
using ITLAStream.Core.Domain.Interfaces.Repositories;
using ITLAStream.Infrastucture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITLAStream.Infrastucture.Persistence.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationContext _dbContext;

        public GeneroRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Genero genero)
        {
            _dbContext.Generos.Add(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genero>> GetAll()
        {
            return await _dbContext.Generos.ToListAsync();
        }

        public async Task<Genero> GetById(int id)
        {
            return await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task Update(Genero genero)
        {
            _dbContext.Generos.Update(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
            if (genero != null)
            {
                _dbContext.Generos.Remove(genero);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
