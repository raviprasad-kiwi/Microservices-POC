using Action.Common.Commands;
using Action.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;
using System.Reflection;
using System.Threading.Tasks;

namespace Action.Common.RabbitMQ
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandlerAsync(msg),
                           ctx => ctx.UseConsumerConfiguration(cfg =>
                           cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                           ctx => ctx.UseConsumerConfiguration(cfg =>
                           cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));




        private static string GetQueueName<T>()=>
            $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOption();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbit.Instantiation.RawRabbitFactory.CreateSingleton(new RawRabbit.Instantiation.RawRabbitOptions
            {
                ClientConfiguration = options
            });
            service.AddSingleton<IBusClient>(_ => client);
        }

    }
}
