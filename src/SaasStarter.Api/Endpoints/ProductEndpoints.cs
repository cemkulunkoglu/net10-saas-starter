using Microsoft.EntityFrameworkCore;
using SaasStarter.Application.Abstractions;
using SaasStarter.Application.Products;
using Wolverine.Http;

namespace SaasStarter.Api.Endpoints;

public static class ProductEndpoints
{
    [WolverineGet("/products")]
    public static Task<List<ProductDto>> List(IAppDbContext db, CancellationToken ct)
    {
        return db.Products
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.CreatedAt))
            .ToListAsync(ct);
    }

    [WolverinePost("/products")]
    public static async Task<IResult> Create(
        CreateProductCommand command,
        IAppDbContext db,
        CancellationToken ct)
    {
        var dto = await CreateProductHandler.HandleAsync(command, db, ct);
        return Results.Created($"/products/{dto.Id}", dto);
    }
}
