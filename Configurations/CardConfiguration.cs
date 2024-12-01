using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Cards>
{
    public void Configure(EntityTypeBuilder<Cards> builder)
    {
        builder.ToTable("cards").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.title).HasMaxLength(100).IsRequired(false);
        builder.Property(c => c.description).HasMaxLength(3000).IsRequired(false);
        builder.Property(c => c.timeStart).IsRequired(false).HasColumnName("time_start");
        builder.Property(c => c.timeEnd).IsRequired(false).HasColumnName("time_end");
        builder.Property(c => c.listId).IsRequired(false).HasColumnName("list_id");
        builder.Property(c => c.order).IsRequired(false);
        builder.Property(c => c.ready).IsRequired(false);
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
        
        builder.HasOne(c => c.List)
            .WithMany(l => l.Cards)
            .HasForeignKey("listId") // Теневое свойство (не существует в модели)
            .OnDelete(DeleteBehavior.Cascade);
    }
}