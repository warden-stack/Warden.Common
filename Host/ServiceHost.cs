using System;
using System.Linq;
using Autofac;
using RawRabbit;
using Warden.Common.Extensions;
using Warden.Messages.Commands;
using Warden.Messages.Events;

namespace Warden.Common.Host
{
    public class ServiceHost : IWebServiceHost
    {
        public void Run()
        {
            Console.WriteLine("Starting service host...");
        }

        public static Builder Create<TStartup>(string name = "")
            where TStartup : class
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = $"Warden Service: {typeof(TStartup).Namespace.Split('.').Last()}";
            }
            Console.Title = name;
            var builder = new Builder();

            return builder;
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class Builder : BuilderBase
        {
            private IResolver _resolver;
            private IBusClient _bus;

            public Builder UseAutofac(ILifetimeScope scope)
            {
                _resolver = new AutofacResolver(scope);

                return this;
            }

            public BusBuilder UseRabbitMq(string queueName = null)
            {
                _bus = _resolver.Resolve<IBusClient>();

                return new BusBuilder(_bus, _resolver, queueName);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost();
            }
        }

        public class BusBuilder : BuilderBase
        {
            private readonly IBusClient _bus;
            private readonly IResolver _resolver;
            private readonly string _queueName;

            public BusBuilder(IBusClient bus, IResolver resolver, string queueName = null)
            {
                _bus = bus;
                _resolver = resolver;
                _queueName = queueName;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var commandHandler = _resolver.Resolve<ICommandHandler<TCommand>>();
                _bus.WithCommandHandlerAsync(commandHandler, _queueName);

                return this;
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var eventHandler = _resolver.Resolve<IEventHandler<TEvent>>();
                _bus.WithEventHandlerAsync(eventHandler, _queueName);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost();
            }
        }
    }
}