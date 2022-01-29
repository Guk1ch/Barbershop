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
    public class OrderController : ControllerBase
    {
        BarbershopContext db;
        public OrderController()
        {
            db = Startup.db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await db.Order.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<string>> Post(Order order)
        {
            if (order == null)
                return BadRequest();

            db.Order.Add(order);
            await db.SaveChangesAsync();
            return Ok("Ok");
        }

        [HttpPut]
        public async Task<ActionResult<string>> Put(Order order)
        {
            var orderF = await db.Order.FirstOrDefaultAsync(obj => obj.IdOrder == order.IdOrder);
            if (order == null || order == null)
                return BadRequest();

            orderF.Done = order.Done;

            await db.SaveChangesAsync();
            return Ok("Ok");
        }

        [HttpDelete]
        [Route("id={id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var order = await db.Order.FirstOrDefaultAsync(obj => obj.IdOrder == id);
            if (order == null)
                return NotFound();

            db.Order.Remove(order);
            await db.SaveChangesAsync();
            return Ok("Ok");
        }
    }
}
