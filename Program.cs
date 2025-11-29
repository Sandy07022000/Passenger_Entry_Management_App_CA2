using Microsoft.EntityFrameworkCore;
// Add this using directive for Pomelo.EntityFrameworkCore.MySql
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Insecure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("InsecureCORS", cors =>
    {
        cors.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// EF Core MySQL connection
// Register DbContext with MySQL
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

// Use CORS
app.UseCors("InsecureCORS");
app.UseAuthorization();
app.MapControllers();
app.Run();