using Microsoft.Extensions.DependencyInjection;

namespace SportRadar.Presentation.API.Extensions
{
    public static class Redis
    {
        public static void ConfigureRedisCache(this IServiceCollection services)
        {
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1:6379";
            });
        }
    }
}
