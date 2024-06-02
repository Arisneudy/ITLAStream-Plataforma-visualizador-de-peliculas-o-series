using ITLAStream.Core.Domain.Entities;
using ITLAStream.Core.Application.ViewModels;

namespace ITLAStream.Core.Application.Interfaces.Repositories
{
    public interface ISerieRepository
    {
        Task Add(Series serie);
        Task<List<Series>> GetAll();
        Task<Series> GetById(int id);
        Task<List<Series>> GetByName(string nombre);
        Task Update(Series serie);
        Task Delete(int id);
        Task<List<Series>> GetAllFilters(FiltroViewModel vm);
    }
}
