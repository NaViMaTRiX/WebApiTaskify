using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class ListConfiguration : IEntityTypeConfiguration<Lists>
{
    public void Configure(EntityTypeBuilder<Lists> builder)
    {
        builder.ToTable("lists").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.title).HasMaxLength(100).IsRequired(false);
        builder.Property(c => c.order).IsRequired(false);
        builder.Property(c => c.boardId).IsRequired(false).HasColumnName("board_id");
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
        //builder.HasOne(x => x.board).WithMany(x => x.lists).HasForeignKey(c => c.boardId).OnDelete(DeleteBehavior.Cascade);
    }
}