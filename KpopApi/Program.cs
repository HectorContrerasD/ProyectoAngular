using Microsoft.EntityFrameworkCore;
using KpopApi.Models.Entities;
using KpopApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebsitosAngularProjectContext>
    (
        x => x.UseMySql("server=65.181.111.21;user=websitos_AngularProject;password=itesrcangular;database=websitos_AngularProject",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.3-mariadb"))
    );
builder.Services.AddTransient<Repository<Kpopgroup>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
