using ITLAStream.Core.Domain.Entities;

namespace ITLAStream.Core.Domain.Interfaces.Repositories
{
    public interface IGeneroRepository
    {
        Task Add(Genero genero);
        Task<List<Genero>> GetAll();
        Task<Genero> GetById(int id);
        Task Update(Genero genero);
        Task Delete(int id);
    }
}
