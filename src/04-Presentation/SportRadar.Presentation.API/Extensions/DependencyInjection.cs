using SportRadar.Application.Contract.Events;
using Microsoft.Extensions.DependencyInjection;
using SportRadar.Domain.Aggregate.Fixture;
using SportRadar.Application.Commands;

namespace SportRadar.Presentation.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IFixtureRepository, FixtureRepository>();
        }

        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddScoped<IApplicationCommandQuery, ApplicationCommandQuery>();
        }
    }
}