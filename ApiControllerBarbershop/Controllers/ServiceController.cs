using ApiControllerBarbershop.Different;
using ApiControllerBarbershop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControllerBarbershop.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        BarbershopContext db;
        public ServiceController()
        {
            db = Startup.db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return await db.Service.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(Service Service)
        {
            if (Service == null)
                return BadRequest();

            db.Service.Add(Service);
            await db.SaveChangesAsync();
            return Ok("Ok");
        }

        [HttpDelete]
        [Route("id={id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var Service = await db.Service.FirstOrDefaultAsync(obj => obj.IdService == id);
            if (Service == null)
                return NotFound();

            db.Service.Remove(Service);
            await db.SaveChangesAsync();
            return Ok("Ok");
        }
    }
}