using Microsoft.EntityFrameworkCore;
using Supercom__Backend.AutoMapper;
using Supercom__Backend.Interfaces;
using Supercom__Backend.Middleware;
using Supercom__Backend.Model;
using Supercom__Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SupercomDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("SupercomConnectionString")));
builder.Services.AddTransient<ITicketsService, TicketsService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
