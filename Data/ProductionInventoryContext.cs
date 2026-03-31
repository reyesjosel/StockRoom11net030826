using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data;

/// <summary>
/// Modern Entity Framework Core DbContext for Production Inventory Database
/// Replaces legacy DataSet/TableAdapter pattern
/// </summary>
public class ProductionInventoryContext : DbContext
{
    public ProductionInventoryContext()
    {
    }

    public ProductionInventoryContext(DbContextOptions<ProductionInventoryContext> options)
        : base(options)
    {
    }

    // DbSets representing your tables
    public DbSet<StockRoom> StockRooms { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Marshall> Marshalls { get; set; } = null!;
    public DbSet<Timeline> Timelines { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Get connection string from configuration
            string connectionString = Properties.Settings.Default.Production_InventoryConnectionString;
            optionsBuilder.UseSqlite(connectionString);

            // Enable detailed logging in debug mode
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
#endif
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure your entities here
        ConfigureStockRoom(modelBuilder);
        ConfigureProjects(modelBuilder);
        ConfigureEmployees(modelBuilder);
        ConfigureLocations(modelBuilder);
        ConfigureMarshalls(modelBuilder);
        ConfigureTimelines(modelBuilder);
    }

    private void ConfigureStockRoom(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockRoom>(entity =>
        {
            entity.ToTable("Table_StockRoom");
            entity.HasKey(e => e.Id);
            // Add indexes for frequently queried columns
            entity.HasIndex(e => e.PartNumber);
            entity.HasIndex(e => e.Description);
        });
    }

    private void ConfigureProjects(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Table_Projects");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.ProjectName);
        });
    }

    private void ConfigureEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Table_Employees");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.EmployeeName);
        });
    }

    private void ConfigureLocations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Table_Locations");
            entity.HasKey(e => e.Id);
        });
    }

    private void ConfigureMarshalls(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marshall>(entity =>
        {
            entity.ToTable("Table_Marshall");
            entity.HasKey(e => e.Id);
        });
    }

    private void ConfigureTimelines(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Timeline>(entity =>
        {
            entity.ToTable("Table_TimeLine");
            entity.HasKey(e => e.Id);
        });
    }
}
