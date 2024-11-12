using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<Board> Board { get; init; }
    public DbSet<List> List { get; init; }
    public DbSet<Card> Card { get; init; }
    public DbSet<Organization> Organization { get; init; }
    public DbSet<AuditLog> AuditLog { get; init; }
    public DbSet<OrgLimit> OrgLimit { get; init; }
    public DbSet<OrgSubscription> OrgSubscription { get; init; }
}