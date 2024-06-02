using ITLAStream.Core.Application.Interfaces.Services;
using ITLAStream.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ITLAStream.Infrastucture.Persistence
{
    public static class InjectionService
    {
        public static void AddApplicationLayer(this IServiceCollection Services)
        {
            // ID
            Services.AddTransient<IGeneroService, GeneroService>();
            Services.AddTransient<IProductoraService, ProductoraService>();
            Services.AddTransient<ISerieService, SerieService>();
        }
    }
}
