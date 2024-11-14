using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organizations>
{
    public void Configure(EntityTypeBuilder<Organizations> builder)
    {
        builder.ToTable("organizations").HasKey(x => x.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.email).HasMaxLength(75).IsRequired(false);
        builder.Property(c => c.description).IsRequired(false).HasMaxLength(900); 
        builder.Property(c => c.address).IsRequired(false).HasMaxLength(300);
        builder.Property(c => c.name).IsRequired(false).HasMaxLength(100);
        builder.Property(c => c.logo).IsRequired(false).HasMaxLength(100);
        builder.Property(c => c.phone).IsRequired(false).HasMaxLength(15);
        builder.Property(c => c.state).IsRequired(false);
        builder.Property(c => c.website).IsRequired(false).HasMaxLength(100);
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
    }
}