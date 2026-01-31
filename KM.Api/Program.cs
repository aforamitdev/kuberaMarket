
using KM.Models.Options;
using KM.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

IConfiguration config = builder.Configuration;
builder.Services.Configure<GraphDbOptions>(config.GetSection("GraphDB"));
builder.Services.AddHttpClient<IGraphDbContext, GraphDbContext>();

var app = builder.Build();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();


