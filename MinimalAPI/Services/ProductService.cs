using MinimalAPI.Models;
using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> ctx;

        public ProductService(DbService mongoDbService)
        {
            ctx = mongoDbService.GetDatabase.GetCollection<Product>("Users");

        }
        public async Task<List<Product>> GetProducts() => await ctx.Find(_ => true).ToListAsync();
        public async Task<Product?> GetProductAsync(string id) => await ctx.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Product newProduct) => await ctx.InsertOneAsync(newProduct);
        public async Task UpdateAsync(string id, Product updateProduct) => await ctx.ReplaceOneAsync(x => x.Id == id, updateProduct);
        public async Task RemoveAsync(string id) => await ctx.DeleteOneAsync(x => x.Id == id);
    }
}
