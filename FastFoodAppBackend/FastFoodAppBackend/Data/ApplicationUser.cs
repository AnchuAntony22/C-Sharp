using Microsoft.AspNetCore.Identity;

namespace FastFoodAppBackend.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string DarkModePreference { get; set; }
        public List<Order> Orders { get; set; }
    }
}
