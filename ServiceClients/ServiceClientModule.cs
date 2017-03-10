using Autofac;

namespace Warden.Common.ServiceClients
{
    public class ServiceClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomHttpClient>()
                .As<IHttpClient>()
                .SingleInstance();

            builder.RegisterType<ServiceClient>()
                .As<IServiceClient>()
                .SingleInstance();
        }
    }
}