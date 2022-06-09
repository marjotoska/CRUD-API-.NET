using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private static List<Client> clients = new List<Client>()
            {
                new Client {
                    Id = 1,
                    FirstName = "Ed",
                    LastName = "Brown",
                    Email = "edbrown@gmail.com"
                },
                new Client {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Travolta",
                    Email = "trtrtr@gmail.com"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = clients.Find(c => c.Id == id);
            if (client == null) return BadRequest("Client not found!");
            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult<Client>> UpdateClient(Client request)
        {
            var client = clients.Find(c => c.Id == request.Id);
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Email = request.Email;
            
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client c)
        {
            clients.Add(c);
            return Ok(clients);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var client = clients.Find(c => c.Id == id);
            if (client == null) return BadRequest("Client not found!");

            clients.Remove(client);
            return Ok(clients);
        }
    }
}
