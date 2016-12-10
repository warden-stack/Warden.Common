using System;
using System.IO;
using Autofac;
using NLog;
using Polly;
using RabbitMQ.Client.Exceptions;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Warden.Common.RabbitMq
{
    public static class RabbitMqContainer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Register(ContainerBuilder builder, RawRabbitConfiguration configuration)
        {
            var policy = Policy
                .Handle<ConnectFailureException>()
                .Or<BrokerUnreachableException>()
                .Or<IOException>()
                .WaitAndRetry(5, retryAttempt =>
                            TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        Logger.Error(exception, "Can not connect to RabbitMQ. " +
                                                $"Retries: {retryCount}, duration: {timeSpan}");
                    }
                );

            builder.RegisterInstance(configuration).SingleInstance();
            policy.Execute(() => builder
                    .RegisterInstance(BusClientFactory.CreateDefault(configuration))
                    .As<IBusClient>()
            );
        }
    }
}