using Annarth.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Annarth.Domain;

namespace Annarth.Infrastructure
{
    public class AnnarthMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public AnnarthMongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Company> Companies => _database.GetCollection<Company>("Company");
        public IMongoCollection<Employee> Employees => _database.GetCollection<Employee>("Employee");
    }
}