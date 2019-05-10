using Action.Common.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RawRabbit;
using RawRabbit.Instantiation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Mongo
{
    public static class Extensions
    {
        public static void AddMOngoDB(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOptions>(configuration.GetSection("mongo"));
            service.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.Connectionstring);
            });
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options;
            });
            service.AddSingleton<IBusClient>(_ => client);
        }
            
    }
}
