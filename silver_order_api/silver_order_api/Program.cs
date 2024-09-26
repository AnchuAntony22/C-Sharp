using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using silver_order_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Replace with your React app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();


        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add MySQL Database Connection
builder.Services.AddDbContext<SilverDb>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Add Cookie Authentication Service
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "UserSession";
        options.Cookie.SameSite = SameSiteMode.None; // Allow cross-origin requests
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are sent only over HTTPS
        options.LoginPath = "/account/login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

var app = builder.Build();
app.UseCors("AllowReactApp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

else
{
    app.UseHttpsRedirection();
}
// Enable authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SilverDb>();
    dbContext.Database.EnsureCreated();
    MenuItemSeeder.Seed(dbContext);
}

app.Run();
