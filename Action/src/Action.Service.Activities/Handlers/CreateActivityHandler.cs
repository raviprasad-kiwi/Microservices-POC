using Action.Common.Commands;
using Action.Common.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Action.Service.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }
        public async Task HandlerAsync(CreateActivity command)
        {
            Console.WriteLine($"Create Activity : {command.Name}");
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name));
        }
    }
}
