using Microsoft.EntityFrameworkCore;
using Together2._0.Data;

var builder = WebApplication.CreateBuilder(args);


var conn = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<TogetherDbContext>(options =>
    options.UseNpgsql(conn));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", builder =>
    {
        builder.WithOrigins("http://localhost:8080" ) 
            .AllowAnyMethod()  
            .AllowAnyHeader(); 
    });
});


builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowVueApp");

app.UseHttpsRedirection();


app.UseAuthorization();


app.MapControllers();

app.Run();