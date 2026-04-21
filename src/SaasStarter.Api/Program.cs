using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SaasStarter.Application;
using SaasStarter.Infrastructure;
using SaasStarter.Infrastructure.Persistence;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

// PostgreSQL bağlantısı (Aspire'dan gelir, connection string adı: "appdb")
builder.AddNpgsqlDbContext<AppDbContext>("appdb");
builder.Services.AddInfrastructure();

// Wolverine: Application assembly'sindeki handler'ları tara
builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(typeof(AssemblyMarker).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    // Dev/test ortamında şemayı garantile (Faz 3'te EF migrations gelecek)
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.MapDefaultEndpoints();
app.MapWolverineEndpoints();

app.Run();

public partial class Program;
