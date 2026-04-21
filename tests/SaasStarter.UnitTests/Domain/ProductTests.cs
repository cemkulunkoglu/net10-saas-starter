using SaasStarter.Domain.Products;

namespace SaasStarter.UnitTests.Domain;

public class ProductTests
{
    [Fact]
    public void Constructor_WithValidArgs_CreatesProduct()
    {
        var product = new Product("Kahve", 49.90m);

        Assert.NotEqual(Guid.Empty, product.Id);
        Assert.Equal("Kahve", product.Name);
        Assert.Equal(49.90m, product.Price);
        Assert.True(product.CreatedAt <= DateTimeOffset.UtcNow);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Constructor_WithEmptyName_Throws(string? name)
    {
        Assert.Throws<ArgumentException>(() => new Product(name!, 10m));
    }

    [Fact]
    public void Constructor_WithNegativePrice_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Kahve", -1m));
    }
}
