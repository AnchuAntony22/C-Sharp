using FastFoodAppBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FastFoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbFood _context;

        public OrderController(AppDbFood context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }

}
