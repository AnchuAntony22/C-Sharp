using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using silver_order_api.Data;
using silver_order_api.Models;
using System.Security.Claims;


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
        [HttpGet("/api/MenuItems")]
        [AllowAnonymous]
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
            return File(menuItem.Image, menuItem.ImageType);
        }

        // Add a new menu item (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]  // Only admins can add items
        public async Task<IActionResult> AddMenuItem([FromForm] MenuItem menuItem, IFormFile image)
        {
            if (menuItem == null)
            {
                return BadRequest(new { message = "Menu item data is missing." });
            }

            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    menuItem.Image = memoryStream.ToArray();
                    menuItem.ImageType = image.ContentType; // Store the image content type
                }
            }
            else
            {
                // If no new image is provided, retain the old image
                menuItem.Image = menuItem.Image;  // Not strictly necessary, but helps clarity
            }

            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return Ok(menuItem); // Return the created menu item
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]  // Only admins can update items
        public async Task<IActionResult> UpdateMenuItem(int id, [FromForm] MenuItem updatedMenuItem, IFormFile image)
        {
            if (id != updatedMenuItem.Id)
            {
                return BadRequest("ID mismatch");
            }

            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound(); // Return 404 if the item doesn't exist
            }

            // Update the item properties
            menuItem.Name = updatedMenuItem.Name;
            menuItem.Price = updatedMenuItem.Price;
           

            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    menuItem.Image = memoryStream.ToArray();
                    menuItem.ImageType = image.ContentType; // Store the image content type
                }
            }

            await _context.SaveChangesAsync();
            return Ok(menuItem);
        }
        // Delete a menu item (Admin only)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]  // Only admins can delete items
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound(new { message = "Menu item not found." });
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            
            return Ok(new { message = "Menu item deleted successfully!" });
        }
    }
}
