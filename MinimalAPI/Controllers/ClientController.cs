using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {

        private readonly ClientService clientService;

        public ClientController(ClientService clientService) => this.clientService = clientService;

        [HttpGet]
        public async Task<List<Client>> GetList() => await clientService.GetClients();

        [HttpGet("{id}")]
        public async Task<Client> Get(string id) => await clientService.GetClientAsync(id);

        [HttpPost]
        public async Task Post(Client client) => await clientService.CreateAsync(client);

        [HttpPut]
        public async Task Update(string id, Client client) => await clientService.UpdateAsync(id, client);

        [HttpDelete]
        public async Task Delete(string id) => await clientService.RemoveAsync(id);
    }
}
