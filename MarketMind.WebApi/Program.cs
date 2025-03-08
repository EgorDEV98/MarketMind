using System.Text.Json.Serialization;
using MarketMind.Data.Extensions;
using MarketMind.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Кастомные сервисы
builder.Services.AddPostgresDbContext(builder.Configuration);
builder.Services.AddServiceOptions(builder.Configuration);
builder.Services.AddTinkoff(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMappers();

var app = builder.Build();
await app.Services.ApplyMigrationAsync();

app.UseSwagger();
app.UseSwaggerUI(x => x.EnableTryItOutByDefault());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();