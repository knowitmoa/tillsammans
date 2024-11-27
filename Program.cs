using Microsoft.EntityFrameworkCore;
using Together2._0.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string for PostgreSQL from the appsettings.json file
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Entity Framework to use PostgreSQL with the provided connection string
builder.Services.AddDbContext<TogetherDbContext>(options =>
    options.UseNpgsql(conn));

// Add Swagger for API documentation in development environment
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS for the frontend on localhost:8080 (Vue app)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", builder =>
    {
        builder.WithOrigins("http://localhost:8080") // Allow Vue frontend on port 8080
            .AllowAnyMethod()  // Allow any HTTP methods (GET, POST, etc.)
            .AllowAnyHeader(); // Allow any headers (e.g., Content-Type)
    });
});


builder.Services.AddControllers();

var app = builder.Build();

// Enable Swagger in the development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS policy globally
app.UseCors("AllowVueApp");

// HTTPS redirection (optional, depending on your environment, you can remove for local dev without HTTPS)
app.UseHttpsRedirection();

// Ensure the use of Authorization middleware if required (e.g., for authentication)
app.UseAuthorization();

// Map controller routes to actions
app.MapControllers();

// Run the app
app.Run();