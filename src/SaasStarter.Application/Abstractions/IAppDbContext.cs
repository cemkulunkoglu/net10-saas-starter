using Microsoft.EntityFrameworkCore;
using SaasStarter.Domain.Products;

namespace SaasStarter.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
