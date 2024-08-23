using Microsoft.AspNetCore.Razor.TagHelpers;
using silver_order_api.Models;

namespace silver_order_api.Data
{
    public class MenuItemSeeder
    {
        public static void Seed(SilverDb context)
        {
            
            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Name = "Ring A",
                    Price = 5099m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s1.webp")
                },
                new MenuItem
                {
                    Name = "Ring B",
                    Price = 5299m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s2.webp")
                },
                new MenuItem
                {
                    Name = "Ring C",
                    Price = 5499m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s3.webp")
                },
                new MenuItem
                {
                    Name = "Ring D",
                    Price = 5699m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s4.webp")
                },
                new MenuItem
                {
                    Name = "Ring E",
                    Price = 5899m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s5.webp")
                },
                new MenuItem
                {
                    Name = "Ring F",
                    Price = 6099m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s6.webp")
                },
                new MenuItem
                {
                    Name = "Ring G",
                    Price = 6299m,
                    Image = ImageHelper.ImageToByteArray(@"F:\netcourse\C_Sharp\silver_order_api\silver_order_api\Image\s7.webp")
                }
            };

            foreach (var item in menuItems)
            {
                context.MenuItems.Add(item);
            }

            context.SaveChanges();
        }
    }
}
