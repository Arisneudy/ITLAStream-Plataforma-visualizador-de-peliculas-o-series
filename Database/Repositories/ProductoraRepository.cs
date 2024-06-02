using ITLAStream.Core.Domain.Interfaces.Repositories;
using ITLAStream.Infrastucture.Persistence.Contexts;
using ITLAStream.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ITLAStream.Infrastucture.Persistence.Repositories
{
    public class ProductoraRepository : IProductoraRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductoraRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Productora productora)
        {
            _dbContext.Productoras.Add(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetAll()
        {
            return await _dbContext.Productoras.ToListAsync();
        }

        public async Task<Productora> GetById(int id)
        {
            return await _dbContext.Productoras.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Productora productora)
        {
            _dbContext.Productoras.Update(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productora = await _dbContext.Productoras.FirstOrDefaultAsync(p => p.Id == id);
            if (productora != null)
            {
                _dbContext.Productoras.Remove(productora);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
