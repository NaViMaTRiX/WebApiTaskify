namespace WebApiTaskify.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {}

    public DbSet<Boards> Boards { get; set; }
    public DbSet<Lists> Lists { get; set; }
    public DbSet<Cards> Cards { get; set; }
    public DbSet<AuditLogs> AuditLogs { get; set; }
    public DbSet<OrgLimits> OrgLimits { get; set; }
    public DbSet<OrgSubscriptions> OrgSubscriptions { get; set; }
}