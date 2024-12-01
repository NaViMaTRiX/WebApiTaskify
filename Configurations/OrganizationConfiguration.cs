using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organizations>
{
    public void Configure(EntityTypeBuilder<Organizations> builder)
    {
        builder.ToTable("organizations").HasKey(x => x.Id);
        builder.Property(c => c.Id).IsRequired().HasColumnName("id");
        builder.Property(c => c.Email).HasMaxLength(75).IsRequired(false).HasColumnName("email");
        builder.Property(c => c.Description).IsRequired(false).HasMaxLength(900).HasColumnName("description");
        builder.Property(c => c.Address).IsRequired(false).HasMaxLength(300).HasColumnName("address");
        builder.Property(c => c.Name).IsRequired(false).HasMaxLength(100).HasColumnName("name");
        builder.Property(c => c.Logo).IsRequired(false).HasMaxLength(100).HasColumnName("logo");
        builder.Property(c => c.Phone).IsRequired(false).HasMaxLength(15).HasColumnName("phone");
        builder.Property(c => c.State).IsRequired(false).HasColumnName("state");
        builder.Property(c => c.Website).IsRequired(false).HasMaxLength(100).HasColumnName("website");
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
    }
}