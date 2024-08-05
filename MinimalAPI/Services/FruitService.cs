using MinimalAPI.Models;
using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class FruitService
    {
        private readonly IMongoCollection<Fruit> ctx;

        public FruitService(DbService mongoDbService)
        {
            ctx = mongoDbService.GetDatabase.GetCollection<Fruit>("Fruits");

        }
        public async Task<List<Fruit>> GetFruits() => await ctx.Find(_ => true).ToListAsync();
        public async Task<Fruit?> GetFruitAsync(string id) => await ctx.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Fruit newFruit) => await ctx.InsertOneAsync(newFruit);
        public async Task UpdateAsync(string id, Fruit updateFruit) => await ctx.ReplaceOneAsync(x => x.Id == id, updateFruit);
        public async Task RemoveAsync(string id) => await ctx.DeleteOneAsync(x => x.Id == id);
    }
}
