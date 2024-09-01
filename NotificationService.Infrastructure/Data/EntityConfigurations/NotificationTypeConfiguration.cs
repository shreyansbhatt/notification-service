using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Data.EntityConfigurations;

public class NotificationTypeConfiguration : IEntityTypeConfiguration<NotificationType>
{
    public void Configure(EntityTypeBuilder<NotificationType> builder)
    {
        builder.HasKey(nt => nt.Id);

        builder.Property(nt => nt.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(nt => nt.Description)
               .HasMaxLength(250);
    }
}
