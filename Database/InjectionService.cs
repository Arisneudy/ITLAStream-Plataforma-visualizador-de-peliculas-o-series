using ITLAStream.Core.Application.Interfaces.Repositories;
using ITLAStream.Core.Domain.Interfaces.Repositories;
using ITLAStream.Infrastucture.Persistence.Contexts;
using ITLAStream.Infrastucture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITLAStream.Infrastucture.Persistence
{
    public static class InjectionService
    {
        public static void AddPersistenceLayer(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ITLAStreamConnection"));
            });


            Services.AddTransient<IGeneroRepository,GeneroRepository>();
            Services.AddTransient<IProductoraRepository, ProductoraRepository>();
            Services.AddTransient<ISerieRepository, SerieRepository>();


            // Aplicar migraciones de forma automática
            using var servicesScope = Services.BuildServiceProvider().CreateScope();
            var dbContext = servicesScope.ServiceProvider.GetRequiredService<ApplicationContext>();
            dbContext.Database.Migrate();
        }
    }
}
