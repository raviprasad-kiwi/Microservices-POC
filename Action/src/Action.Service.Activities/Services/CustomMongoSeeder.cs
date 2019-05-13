using Action.Common.Mongo;
using Action.Service.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Action.Service.Activities.Services
{
    public class CustomMongoSeeder:MongoSeeder
    {
        private readonly IMongoDatabase _database;
        private readonly ICategoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase database, ICategoryRepository categoryRepository) :base(database)
        {
            _database = database;
            _categoryRepository = categoryRepository;
        }
        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };
            await Task.WhenAll(categories.Select(v => _categoryRepository.AddAsync(new Domain.Models.Category(v))));
        }
    }
}
