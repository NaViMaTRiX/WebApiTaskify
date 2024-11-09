using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<Board> Board { get; set; }
    public DbSet<List> List { get; set; }
    public DbSet<Card> Card { get; set; }
    public DbSet<AuditLog> AuditLog { get; set; }
    public DbSet<OrgLimit> OrgLimit { get; set; }
    public DbSet<OrgSubscription> OrgSubscription { get; set; }
}