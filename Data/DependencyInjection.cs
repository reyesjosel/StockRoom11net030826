using Microsoft.Extensions.DependencyInjection;

namespace StockRoom11net.Data;

/// <summary>
/// Dependency Injection configuration for EF Core and services
/// Modern best practice for .NET applications
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        // Register DbContext with scoped lifetime
        services.AddDbContext<ProductionInventoryContext>(ServiceLifetime.Scoped);

        // Register Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register Services
        services.AddScoped<IStockRoomService, StockRoomService>();

        return services;
    }

    /// <summary>
    /// Create a new scope and resolve service
    /// Use this pattern in WinForms to get services
    /// </summary>
    public static T GetService<T>() where T : notnull
    {
        return ServiceProviderFactory.ServiceProvider.GetRequiredService<T>();
    }

    /// <summary>
    /// Create a new scope for long-running operations
    /// Always dispose the scope when done
    /// </summary>
    public static IServiceScope CreateScope()
    {
        return ServiceProviderFactory.ServiceProvider.CreateScope();
    }
}

/// <summary>
/// Static service provider factory for WinForms
/// Initialize this in Program.cs
/// </summary>
public static class ServiceProviderFactory
{
    private static IServiceProvider? _serviceProvider;

    public static IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException(
                    "Service provider not initialized. Call Initialize() in Program.cs");
            }
            return _serviceProvider;
        }
    }

    public static void Initialize()
    {
        var services = new ServiceCollection();

        // Add all data services
        services.AddDataServices();

        // Build the service provider
        _serviceProvider = services.BuildServiceProvider();
    }

    public static void Dispose()
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
