using Microsoft.AspNetCore.Razor.TagHelpers;
using silver_order_api.Models;

namespace silver_order_api.Data
{
    public class MenuItemSeeder
    {
        public static void Seed(SilverDb context)
        {
            // Check if there are any MenuItems already in the database
            if (context.MenuItems.Any())
            {
                return; // Exit if the database already has MenuItems
            }

            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Name = "Ring A",
                    Price = 5099m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s1.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring B",
                    Price = 5299m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s2.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring C",
                    Price = 5499m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s3.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring D",
                    Price = 5699m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s4.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring E",
                    Price = 5899m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s5.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring F",
                    Price = 6099m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s6.webp"),
                    ImageType = "image/webp"
                },
                new MenuItem
                {
                    Name = "Ring G",
                    Price = 6299m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s7.webp"),
                    ImageType = "image/webp"
                }
            };

            // Add the items to the context and save changes
            context.MenuItems.AddRange(menuItems);
            context.SaveChanges();
        }

    }
}
