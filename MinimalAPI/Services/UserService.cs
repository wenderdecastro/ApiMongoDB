using MinimalAPI.Models;
using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> ctx;

        public UserService(DbService mongoDbService)
        {
            ctx = mongoDbService.GetDatabase.GetCollection<User>("Users");

        }

        public async Task<List<User>> GetUsers() => await ctx.Find(_ => true).ToListAsync();
        public async Task<User?> GetUserAsync(string id) => await ctx.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(User newUser) => await ctx.InsertOneAsync(newUser);
        public async Task UpdateAsync(string id, User updateUser) => await ctx.ReplaceOneAsync(x => x.Id == id, updateUser);
        public async Task RemoveAsync(string id) => await ctx.DeleteOneAsync(x => x.Id == id);
    }
}
