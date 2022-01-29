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
    public class TypeServiceController : ControllerBase
    {
        BarbershopContext db;
        public TypeServiceController()
        {
            db = Startup.db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeService>>> Get()
        {
            return await db.TypeService.ToListAsync();
        }
    }
}