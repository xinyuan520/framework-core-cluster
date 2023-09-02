using Discus.Shared.Webapi.Registrar;

namespace Discus.User.WebApi.Registrar
{
    public sealed class UserWebApiApplicationDependencyRegistrar : AbstractWebApiDependencyRegistrar
    {
        public UserWebApiApplicationDependencyRegistrar(IServiceCollection services) : base(services)
        {
        }

        public UserWebApiApplicationDependencyRegistrar(IApplicationBuilder app) : base(app)
        {

        }

        public override void AddService()
        {
            AddWebApiDefault();
        }

        public override void UseSharedDefault()
        {
            UseWebApiDefault(endpointRoute: endpoint =>
            {
            });
        }
    }
}
