using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Boards> Board { get; init; }
    public DbSet<Lists> List { get; init; }
    public DbSet<Cards> Card { get; init; }
    public DbSet<Organizations> Organization { get; init; }
    public DbSet<AuditLogs> AuditLog { get; init; }
    public DbSet<OrgLimits> OrgLimit { get; init; }
    public DbSet<OrgSubscriptions> OrgSubscription { get; init; }
}