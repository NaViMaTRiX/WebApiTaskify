using Npgsql;
using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
    : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        NpgsqlConnection.GlobalTypeMapper.EnableUnmappedTypes();

        // Получаем строку подключения из конфигурации
        var connectionString = configuration.GetConnectionString("TestCopy");

        // Настраиваем DataSource с EnableUnmappedTypes
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.EnableUnmappedTypes();
        var dataSource = dataSourceBuilder.Build();

        // Используем DataSource для подключения
        optionsBuilder.UseNpgsql(dataSource);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<ACTION>("public", "action");
        modelBuilder.HasPostgresEnum<ENTITY_TYPE>("public","entity_type");
        
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