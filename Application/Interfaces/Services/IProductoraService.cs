using ITLAStream.Core.Application.ViewModels;

namespace ITLAStream.Core.Application.Interfaces.Services
{
    public interface IProductoraService
    {
        Task Add(CreateProductoraViewModel vm);
        Task Delete(int id);
        Task<List<ProducturaViewModel>> GetAll();
        Task<CreateProductoraViewModel> GetById(int id);
        Task Update(CreateProductoraViewModel vm);
    }
}