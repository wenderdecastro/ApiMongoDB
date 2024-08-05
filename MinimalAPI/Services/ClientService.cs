using MinimalAPI.Models;
using MongoDB.Driver;

namespace MinimalAPI.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> ctx;

        public ClientService(DbService mongoDbService)
        {
            ctx = mongoDbService.GetDatabase.GetCollection<Client>("Clients");

        }

        public async Task<List<Client>> GetClients() => await ctx.Find(_ => true).ToListAsync();
        public async Task<Client?> GetClientAsync(string id) => await ctx.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Client newClient) => await ctx.InsertOneAsync(newClient);
        public async Task UpdateAsync(string id, Client updateClient) => await ctx.ReplaceOneAsync(x => x.Id == id, updateClient);
        public async Task RemoveAsync(string id) => await ctx.DeleteOneAsync(x => x.Id == id);
    }
}
