using ITLAStream.Core.Application.ViewModels;

namespace ITLAStream.Core.Application.Interfaces.Services
{
    public interface ISerieService
    {
        Task Add(CreateSerieViewModel vm);
        Task Delete(int id);
        Task<List<SerieViewModel>> GetAll();
        Task<List<SerieViewModel>> GetAllFilters(FiltroViewModel vm);
        Task<CreateSerieViewModel> GetById(int id);
        Task<List<SerieViewModel>> GetByName(string nombre);
        Task Update(CreateSerieViewModel vm);
    }
}