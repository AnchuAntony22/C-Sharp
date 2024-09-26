using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using silver_order_api.Data;
using Microsoft.EntityFrameworkCore;


namespace silver_order_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SilverDb _context;

        public AccountController(SilverDb context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest signupRequest)
        {
            if (signupRequest == null || string.IsNullOrEmpty(signupRequest.Username) || string.IsNullOrEmpty(signupRequest.Password))
            {
                return BadRequest(new { message = "Username and password must be provided." });
            }

            // Check if user already exists
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == signupRequest.Username);
            if (existingUser != null)
            {
                return Conflict(new { message = "User already exists." });
            }

            // Create new user with original password
            var newUser = new User
            {
                Username = signupRequest.Username,
                PasswordHash = signupRequest.Password, // Store the original password
                Role = signupRequest.Role ?? "User"  // Default role is "User", but you can pass "Admin"
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User created successfully!" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { message = "Username and password must be provided." });
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginRequest.Username);
            if (user == null || user.PasswordHash != loginRequest.Password) // Compare directly with original password
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            //if (user.Role == "Admin")
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            //}
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Ok(new { message = "Login successful!", role = user.Role }); // Include role in response
        }

        // Logout action
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Logout successful!" });
        }

        

        
    }
}
