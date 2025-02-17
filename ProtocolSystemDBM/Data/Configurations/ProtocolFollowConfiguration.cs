using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Data.Configurations
{
    public class ProtocolFollowConfiguration : IEntityTypeConfiguration<ProtocolFollow>
    {
        public void Configure(EntityTypeBuilder<ProtocolFollow> builder)
        {
            builder.ToTable("protocol_follows");

            builder.HasKey(x => x.Id);
            builder.Property(protocolFollow => protocolFollow.Id)
                .HasColumnName("id");

            builder.Property(protocolFollow => protocolFollow.ActionDescription)
                   .HasColumnName("action_description")
                   .IsRequired();

            builder.Property(protocolFollow => protocolFollow.ActionDate)
                   .HasColumnName("action_date")
                   .IsRequired();

            builder.HasOne(protocolFollow => protocolFollow.Protocol)
                   .WithMany(protocol => protocol.ProtocolFollows)
                   .HasForeignKey(protocolFollow => protocolFollow.ProtocolId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(protocolFollow => protocolFollow.ProtocolId)
                   .HasColumnName("protocol_id")
                   .IsRequired();
        }
    }
}
