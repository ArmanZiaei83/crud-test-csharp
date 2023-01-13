using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Persistence.Contexts;

public class EFDataContext : DbContext
{
    public EFDataContext(DbContextOptions<EFDataContext> options) : base(
        options)
    {
    }

    public EFDataContext(string connectionString)
        : this(new DbContextOptionsBuilder<EFDataContext>()
            .UseSqlServer(connectionString).Options)
    {
    }

    public override ChangeTracker ChangeTracker
    {
        get
        {
            ChangeTracker? tracker = base.ChangeTracker;
            tracker.LazyLoadingEnabled = false;
            tracker.AutoDetectChangesEnabled = true;
            tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return tracker;
        }
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext)
            .Assembly);
    }
}