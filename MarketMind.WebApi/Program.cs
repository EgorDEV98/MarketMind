using MarketMind.Data.Extensions;
using MarketMind.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();