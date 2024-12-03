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
        // Получаем строку подключения из конфигурации
        var builder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("TestCopy"))
            .EnableDynamicJson();
        
        // Настраиваем сопоставление типов Enum
        builder.MapEnum<ACTION>("action");
        builder.MapEnum<ENTITY_TYPE>("entity_type");

        // Строим DataSource и передаем его в UseNpgsql
        var dataSource = builder.Build();
        optionsBuilder.UseNpgsql(dataSource);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Регистрируем Enum в модели
        modelBuilder.HasPostgresEnum<ACTION>("action");
        modelBuilder.HasPostgresEnum<ENTITY_TYPE>("entity_type");
        
        //Подключаем комфигурацию db
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