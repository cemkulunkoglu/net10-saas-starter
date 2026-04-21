using SaasStarter.Application.Abstractions;
using SaasStarter.Domain.Products;

namespace SaasStarter.Application.Products;

public static class CreateProductHandler
{
    public static async Task<ProductDto> HandleAsync(
        CreateProductCommand command,
        IAppDbContext db,
        CancellationToken cancellationToken)
    {
        var product = new Product(command.Name, command.Price);
        db.Products.Add(product);
        await db.SaveChangesAsync(cancellationToken);

        return new ProductDto(product.Id, product.Name, product.Price, product.CreatedAt);
    }
}
