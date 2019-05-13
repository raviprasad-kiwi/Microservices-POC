using Action.Service.Activities.Domain.Models;
using Action.Service.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Action.Service.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;
        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(Activity activity) => await Collection.InsertOneAsync(activity);
        

        public async Task<Activity> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(b => b.Id == id);
        
        public IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activity");
    }
}
