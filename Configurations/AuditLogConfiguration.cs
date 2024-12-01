using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLogs>
{
    public void Configure(EntityTypeBuilder<AuditLogs> builder)
    {
        builder.ToTable("audit_logs").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.action).IsRequired(false).HasColumnType("action");
        builder.Property(c => c.entityId).IsRequired(false).HasColumnName("entity_id").HasMaxLength(100);
        builder.Property(c => c.entityTitle).IsRequired(false).HasColumnName("entity_title").HasMaxLength(100);
        builder.Property(c => c.entityType).IsRequired(false).HasColumnType("entity_type").HasColumnName("entity_type");
        builder.Property(c => c.orgId).IsRequired(false).HasColumnName("org_id").HasMaxLength(100);
        builder.Property(c => c.userId).IsRequired(false).HasColumnName("user_id").HasMaxLength(100);
        builder.Property(c => c.userName).IsRequired(false).HasMaxLength(100).HasColumnName("user_name");
        builder.Property(c => c.userImage).IsRequired(false).HasMaxLength(300).HasColumnName("user_image");
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
    }
}