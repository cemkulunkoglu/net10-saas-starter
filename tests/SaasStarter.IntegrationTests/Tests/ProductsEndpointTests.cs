using System.Net;
using System.Net.Http.Json;
using Aspire.Hosting;
using Microsoft.Extensions.Http.Resilience;
using SaasStarter.Application.Products;

namespace SaasStarter.IntegrationTests.Tests;

public class ProductsEndpointTests
{
    private static readonly TimeSpan StartupTimeout = TimeSpan.FromMinutes(3);

    [Fact]
    public async Task CanCreateAndListProducts()
    {
        var cancellationToken = CancellationToken.None;

        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.SaasStarter_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(c =>
            c.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(StartupTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(StartupTimeout, cancellationToken);

        using var client = app.CreateHttpClient("api");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("api", cancellationToken)
            .WaitAsync(StartupTimeout, cancellationToken);

        // Create
        var createResponse = await client.PostAsJsonAsync(
            "/products",
            new CreateProductCommand("Türk Kahvesi", 49.90m),
            cancellationToken);

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

        var created = await createResponse.Content
            .ReadFromJsonAsync<ProductDto>(cancellationToken);
        Assert.NotNull(created);
        Assert.Equal("Türk Kahvesi", created!.Name);
        Assert.NotEqual(Guid.Empty, created.Id);

        // List
        var list = await client.GetFromJsonAsync<List<ProductDto>>(
            "/products",
            cancellationToken);

        Assert.NotNull(list);
        Assert.Contains(list!, p => p.Id == created.Id);
    }
}
