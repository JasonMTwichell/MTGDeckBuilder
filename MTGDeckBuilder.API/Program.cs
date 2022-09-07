using MTGDeckBuilder.API;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IMTGConfiguration, MTGDeckBuilderApiConfiguration>();
builder.Services.AddTransient<MTGDeckBuilderContext, MTGDeckBuilderContext>();
builder.Services.AddTransient<IMTGDeckBuilderRepository, MTGDeckBuilderRepository>();
builder.Services.AddTransient<IMTGDeckBuilderService, IMTGDeckBuilderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
