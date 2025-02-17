using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id)
                   .HasColumnName("id");

            builder.Property(user => user.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(user => user.Email)
                   .HasColumnName("email")
                   .IsRequired();

            builder.Property(user => user.Phone)
                   .HasColumnName("phone")
                   .IsRequired();

            builder.Property(user => user.Address)
                   .HasColumnName("address")
                   .IsRequired();

            builder.HasMany(user => user.Protocols)
                   .WithOne(protocol => protocol.User)
                   .HasForeignKey(protocol => protocol.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
