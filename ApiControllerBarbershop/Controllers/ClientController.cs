using ApiControllerBarbershop.Different;
using ApiControllerBarbershop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControllerBarbershop.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        BarbershopContext db;
        public ClientController()
        {
            db = Startup.db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Client.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<string>> Post(Client client)
        {
            var clientF = await db.Client.FirstOrDefaultAsync(obj => obj.Login == client.Login);
            if (client == null || clientF != null)
                return BadRequest();

            db.Client.Add(client);
            await db.SaveChangesAsync();
            return Ok("Ok");
        }
    }
}
