
using KM.Application.Repository;
using KM.Application.Services;
using KM.Infrastructure.GraphDB;
using KM.Models.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration config = builder.Configuration;

builder.Services.Configure<GraphDbOptions>(config.GetSection("GraphDB"));

builder.Services.AddHttpClient<IGraphDbContext, GraphDbContext>();

builder.Services.AddScoped<IExchangeRepository, ExchangeRepository>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();

var app = builder.Build();

    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();


app.MapControllers();
app.UseHttpsRedirection();



app.Run();


