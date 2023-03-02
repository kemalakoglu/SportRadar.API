using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SportRadar.Presentation.API.Extensions
{
    public static class Swagger
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SportRadar", new OpenApiInfo
                {
                    Title = "SportRadar API",
                    Version = "SportRadar",
                    Description = "SportRadar Web API Documentation",
                });
            });
        }
    }
}