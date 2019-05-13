﻿using Action.Common.RabbitMQ;
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
        public static void AddMongoDB(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOptions>(configuration.GetSection("mongo"));
            service.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.Connectionstring);
            });
            service.AddScoped<IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoClient>();
                return client.GetDatabase(options.Value.Database);
            });
            service.AddScoped<IDatabaseInitializer, MongoInitializer>();
            service.AddScoped<IDatabaseSeeder, MongoSeeder>();
        }
            
    }
}
