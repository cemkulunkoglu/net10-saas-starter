namespace SaasStarter.Domain.Products;

public sealed class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private Product()
    {
        // EF Core
        Name = string.Empty;
    }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Ürün adı boş olamaz", nameof(name));
        }

        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Fiyat negatif olamaz");
        }

        Id = Guid.CreateVersion7();
        Name = name;
        Price = price;
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
