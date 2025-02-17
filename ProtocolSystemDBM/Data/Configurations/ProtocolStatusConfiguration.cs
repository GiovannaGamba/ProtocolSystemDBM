using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Data.Configurations
{
    public class ProtocolStatusConfiguration : IEntityTypeConfiguration<ProtocolStatus>
    {
        public void Configure(EntityTypeBuilder<ProtocolStatus> builder)
        {
            builder.ToTable("protocol_statuses");

            builder.HasKey(x => x.Id);
            builder.Property(protocolStatus => protocolStatus.Id)
                    .HasColumnName("id"); ;

            builder.Property(protocolStatus => protocolStatus.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(protocolStatus => protocolStatus.Deleted)
                   .HasColumnName("deleted")
                   .IsRequired();

            builder.HasMany(protocolStatus => protocolStatus.Protocols)
                   .WithOne(protocol => protocol.ProtocolStatus)
                   .HasForeignKey(protocol => protocol.ProtocolStatusId);

            builder.HasData(
                new ProtocolStatus("Criado") { Id = Guid.Parse("a2b32f72-2c91-47f6-b0a9-63e9b44b33f9") },
                new ProtocolStatus("Em processamento") { Id = Guid.Parse("f34be16e-d2ae-45d7-8f97-060f0cd541b2") },
                new ProtocolStatus("Atendido") { Id = Guid.Parse("be0f2111-f6da-4208-b6f7-6e63f27b0428") }
            );
        }
    }
}
