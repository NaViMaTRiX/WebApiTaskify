using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTaskify.Models;

namespace WebApiTaskify.Configurations;

public class OrgSubscriptionConfiguration : IEntityTypeConfiguration<OrgSubscriptions>
{
    public void Configure(EntityTypeBuilder<OrgSubscriptions> builder)
    {
        builder.ToTable("org_subscriptions").HasKey(c => c.id);
        builder.Property(c => c.id).IsRequired();
        builder.Property(c => c.stripe_customer_id).HasMaxLength(300).IsRequired(false).HasColumnName("stripe_customer_id");
        builder.Property(c => c.stripe_price_id).IsRequired(false).HasColumnName("stripe_price_id").HasMaxLength(300);
        builder.Property(c => c.stripe_subscription_id).IsRequired(false).HasColumnName("stripe_subscription_id").HasMaxLength(300);
        builder.Property(c => c.orgId).IsRequired(false).HasColumnName("org_id").HasMaxLength(100);
        builder.Property(c => c.createdTime).IsRequired().HasColumnName("created_time");
        builder.Property(c => c.lastModifyTime).IsRequired().HasColumnName("last_modify_time");
        builder.Property(c => c.createdUser).IsRequired(false).HasColumnName("created_user");
        builder.Property(c => c.lastModifyUser).IsRequired(false).HasColumnName("last_modify_user");
        
    }
}