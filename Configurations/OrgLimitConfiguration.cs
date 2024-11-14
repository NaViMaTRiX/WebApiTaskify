using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class OrgLimitConfiguration : IEntityTypeConfiguration<OrgLimits>
{
    public void Configure(EntityTypeBuilder<OrgLimits> builder)
    {
        builder.ToTable("org_limits").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.count).IsRequired(false);
        builder.Property(c => c.orgId).IsRequired(false).HasColumnName("org_id").HasMaxLength(100);
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
    }
}