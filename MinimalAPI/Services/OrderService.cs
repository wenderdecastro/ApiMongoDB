using MinimalAPI.Models;
using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> ctx;

        public OrderService(DbService mongoDbService)
        {
            ctx = mongoDbService.GetDatabase.GetCollection<Order>("Orders");

        }

        public async Task<List<Order>> GetOrders() => await ctx.Find(_ => true).ToListAsync();
        public async Task<Order?> GetOrderAsync(string id) => await ctx.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Order newOrder) => await ctx.InsertOneAsync(newOrder);
        public async Task UpdateAsync(string id, Order updateOrder) => await ctx.ReplaceOneAsync(x => x.Id == id, updateOrder);
        public async Task RemoveAsync(string id) => await ctx.DeleteOneAsync(x => x.Id == id);
    }
}
