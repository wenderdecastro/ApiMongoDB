using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class DbService
    {
        private readonly IMongoDatabase _database;

        public DbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase GetDatabase => _database;
    }
}
