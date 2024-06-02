using ITLAStream.Core.Domain.Entities;

namespace ITLAStream.Core.Domain.Interfaces.Repositories
{
    public interface IProductoraRepository
    {
        Task Add(Productora productora);
        Task<List<Productora>> GetAll();
        Task<Productora> GetById(int id);
        Task Update(Productora productora);
        Task Delete(int id);
    }
}
