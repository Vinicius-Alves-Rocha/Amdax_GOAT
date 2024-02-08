using Service.Commands;
using Service.Repositories;
using Service.Repositories.Interfaces;

namespace Api
{
    public static class DependencyInjectionConfigurator
    {
        public static void ConfigureDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IApplicantRepository, ApplicantRepository>();

            serviceCollection.ConfigureMediatorDependecyInjection();
        }

        private static void ConfigureMediatorDependecyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateApplicantReviewCommand).Assembly));
        }
    }
}
