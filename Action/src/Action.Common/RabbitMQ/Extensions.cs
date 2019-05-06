using Action.Common.Commands;
using Action.Common.Events;
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
            ICommandHandler<TEvent> handler) where TEvent : ICommand
            => bus.SubscribeAsync<TEvent>(msg => handler.HandlerAsync(msg),
                           ctx => ctx.UseConsumerConfiguration(cfg =>
                           cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));




        private static string GetQueueName<T>()=>
            $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

    }
}
