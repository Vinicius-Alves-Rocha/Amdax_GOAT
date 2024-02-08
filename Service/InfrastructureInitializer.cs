using Microsoft.Extensions.DependencyInjection;

using Service.Repositories.Context;

namespace Service
{
    public static class InfrastructureInitializer
    {
        public static void ConfigureInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AmdaxDbContext>();
        }

    }
}
