using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Action.Api.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;
        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            await _busClient.PublishAsync(command);
            return Accepted($"activites/{command.Id}");
        }
    }
}