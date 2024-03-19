using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using PetFormation_APIS.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PetFormationDbContext>(options => 
    options.UseMySQL(builder.Configuration.GetConnectionString("PetFormationConnectionString"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

//app.Run();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5275"; // Utilizar el puerto 5275 como predeterminado si no se especifica ning�n otro
app.Run($"http://localhost:{port}");
