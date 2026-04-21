namespace SaasStarter.Application.Products;

public sealed record CreateProductCommand(string Name, decimal Price);

public sealed record ProductDto(Guid Id, string Name, decimal Price, DateTimeOffset CreatedAt);
