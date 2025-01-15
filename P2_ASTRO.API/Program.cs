using Microsoft.EntityFrameworkCore;
using P2_ASTRO.API.Data;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Service;
using P2_ASTRO.API.Util;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cbcontext and connect it to connection string
builder.Services.AddDbContext<AstroContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AstroDB")));

//Add service dependencies
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IPODService, PODService>();

//Add repo dependencies
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IPODRepository, PODRepository>();

//Use singleton for utilies
builder.Services.AddSingleton<Utility>(); 

//Add controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();