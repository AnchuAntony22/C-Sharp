using Microsoft.AspNetCore.Mvc;
using silver_order_api.Data;
using silver_order_api.Models;
using System;


namespace silver_order_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly SilverDb _context;
        public MenuItemsController(SilverDb context) 
        { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMenuItems()
        {
            var menuItems = _context.MenuItems.ToList();

            return Ok(menuItems);
        }

        [HttpGet("{id}/image")]
        public IActionResult GetImage(int id)
        {
            var menuItem = _context.MenuItems.Find(id);
            if (menuItem == null || menuItem.Image == null)
            {
                return NotFound();
            }

            return File(menuItem.Image, "image/webp"); 
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
