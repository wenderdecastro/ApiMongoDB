using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FruitsController : ControllerBase
    {

        private readonly FruitService fruitService;

        public FruitsController(FruitService fruitService) => this.fruitService = fruitService;

        [HttpGet]
        public async Task<List<Fruit>> GetList() => await fruitService.GetFruits();

        [HttpGet("{id}")]
        public async Task<Fruit> Get(string id) => await fruitService.GetFruitAsync(id);

        [HttpPost]
        public async Task Post(Fruit fruit) => await fruitService.CreateAsync(fruit);

        [HttpPut]
        public async Task Update(string id, Fruit fruit) => await fruitService.UpdateAsync(id, fruit);

        [HttpDelete]
        public async Task Delete(string id) => await fruitService.RemoveAsync(id);
    }
}
