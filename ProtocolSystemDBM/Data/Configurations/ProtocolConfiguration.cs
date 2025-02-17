using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Data.Configurations
{
    public class ProtocolConfiguration : IEntityTypeConfiguration<Protocol>
    {
        public void Configure(EntityTypeBuilder<Protocol> builder)
        {
            builder.ToTable("protocols");

            builder.HasKey(x => x.Id);
            builder.Property(protocol => protocol.Id)
                   .HasColumnName("id");

            builder.Property(protocol => protocol.Title)
                   .HasColumnName("title")
                   .IsRequired();

            builder.Property(protocol => protocol.Description)
                   .HasColumnName("description")
                   .IsRequired();

            builder.Property(protocol => protocol.OpeningDate)
                   .HasColumnName("opening_date")
                   .IsRequired();

            builder.Property(protocol => protocol.ClosingDate)
                   .HasColumnName("closing_date")
                   .IsRequired(false);

            builder.HasOne(protocol => protocol.User)
                   .WithMany(user => user.Protocols)
                   .HasForeignKey(protocol => protocol.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(protocol => protocol.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.HasOne(protocol => protocol.ProtocolStatus)
                   .WithMany(protocolStatus => protocolStatus.Protocols)
                   .HasForeignKey(protocol => protocol.ProtocolStatusId);

            builder.Property(protocol => protocol.ProtocolStatusId)
                   .HasColumnName("protocol_status_id")
                   .IsRequired();

            builder.HasMany(protocol => protocol.ProtocolFollows)
                   .WithOne(follow => follow.Protocol)
                   .HasForeignKey(follow => follow.ProtocolId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
