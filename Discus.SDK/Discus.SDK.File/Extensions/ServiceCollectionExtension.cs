using Discus.SDK.File.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata.Ecma335;

namespace Discus.SDK.File.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceMinio(this IServiceCollection services, IConfigurationSection minioSection)
        {
            if (services.HasRegistered(nameof(AddServiceMinio)))
                return services;

            services.Configure<MinioConfig>(minioSection)
                .AddSingleton(provider => {
                    var options = provider.GetRequiredService<IOptions<MinioConfig>>();
                    var minioClient = new MinioClient().WithEndpoint(options.Value.Endpoint)
                                         .WithCredentials(options.Value.AccessKey, options.Value.SecretKey)
                                         .WithSSL(options.Value.Secure)
                                         .Build();
                    return minioClient;
                })
                .AddSingleton<IStorageClient, StorageClient>();
            return services;

        }
    }
}
