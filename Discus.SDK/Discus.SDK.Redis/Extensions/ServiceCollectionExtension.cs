using Discus.SDK.Core.System.Extensions;
using Discus.SDK.Redis.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Discus.SDK.Redis.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceRedis(this IServiceCollection services, IConfigurationSection redisSection)
        {
            if (services.HasRegistered(nameof(AddServiceRedis)))
                return services;

            services.Configure<RedisConfiguration>(redisSection)
                .AddSingleton(provider =>
                {
                    var options = provider.GetRequiredService<IOptions<RedisConfiguration>>();
                    var redisClient =  new CSRedisClient(options.Value.Dbconfig.ConnectionString);
                    return redisClient;
                })
                .AddSingleton<IRedisClient, RedisClient>()
                .AddSingleton<IDistributedLocker, DistributedLocker>();
            return services;
        }
    }
}
