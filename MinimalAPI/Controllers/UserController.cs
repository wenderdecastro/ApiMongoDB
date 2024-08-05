using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Services;
using MongoDB.Driver;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {

        private readonly IMongoCollection<User> userCtx;

        public UserController(DbService mongoDbService)
        {
            userCtx = mongoDbService.GetDatabase.GetCollection<User>("Users");

        }

        [HttpGet]
        public async Task<List<User>> GetList() => await userCtx.Find(_ => true).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id) => await userCtx.Find(x => x.Id == id).FirstOrDefaultAsync() == null ? Ok(userCtx.Find(x => x.Id == id).FirstOrDefaultAsync()) : NotFound();

        [HttpPost]
        public async Task Post(User newUser) => await userCtx.InsertOneAsync(newUser);

        [HttpPut]
        public async Task Update(string id, User updateUser) => await userCtx.ReplaceOneAsync(x => x.Id == id, updateUser);

        [HttpDelete]
        public async Task Delete(string id) => await userCtx.DeleteOneAsync(x => x.Id == id);

    }
}
