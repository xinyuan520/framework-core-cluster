using Dapper;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using Discus.SDK.Repository.Dapper.Repository;
using Microsoft.Extensions.Configuration;
using Discus.SDK.Repository.Dapper.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace Discus.SDK.Repository.Dapper.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, IConfigurationSection mysqlSection)
        {
            if (services.HasRegistered(nameof(AddDapper)))
                return services;

            services.Configure<MysqlConfiguration>(mysqlSection)
                .AddSingleton<IDapperRepository, DapperRepository>(service => {
                    return new DapperRepository(new MySqlConnection(mysqlSection.GetValue<string>("ConnectionString")));
                });
            return services;
        }
    }
}
