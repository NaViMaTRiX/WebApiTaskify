using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class BoardConfiguration : IEntityTypeConfiguration<Boards>
{
    public void Configure(EntityTypeBuilder<Boards> builder)
    {
        builder.ToTable("boards").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.title).HasMaxLength(100).IsRequired(false);
        builder.Property(c => c.imageFullUrl).IsRequired(false).HasMaxLength(300).HasColumnName("image_full_url");
        builder.Property(c => c.imageThumbUrl).IsRequired(false).HasMaxLength(300).HasColumnName("image_thumb_url");
        builder.Property(c => c.imageFullUrl).IsRequired(false).HasMaxLength(300).HasColumnName("image_full_url");
        builder.Property(c => c.imageUserName).IsRequired(false).HasMaxLength(300).HasColumnName("image_user_name");
        builder.Property(c => c.imageLinkHTML).IsRequired(false).HasMaxLength(300).HasColumnName("image_link_html");
        builder.Property(c => c.imageId).IsRequired(false).HasMaxLength(300);
        builder.Property(c => c.orgId).IsRequired(false).HasColumnName("org_id").HasMaxLength(100);
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
    }
}