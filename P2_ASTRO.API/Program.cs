using Microsoft.EntityFrameworkCore;
using P2_ASTRO.API.Data;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API;



var builder = WebApplication.CreateBuilder(args);


// Add cbcontext and connect it to connection string
builder.Services.AddDbContext<AstroContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AstroDB")));

// Add services to the container.
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

app.UseHttpsRedirection();


app.Run();