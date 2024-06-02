using ITLAStream.Core.Application.ViewModels;

namespace ITLAStream.Core.Application.Interfaces.Services
{
    public interface IGeneroService
    {
        Task Add(CreateGeneroViewModel vm);
        Task Delete(int id);
        Task<List<GeneroViewModel>> GetAll();
        Task<CreateGeneroViewModel> GetById(int id);
        Task Update(CreateGeneroViewModel vm);
    }
}