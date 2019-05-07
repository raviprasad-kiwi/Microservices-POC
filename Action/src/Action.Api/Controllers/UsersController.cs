﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Action.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {   
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}