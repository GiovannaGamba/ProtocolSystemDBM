using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Models;

public class ProtocolSystemDbContext : DbContext
{
    public ProtocolSystemDbContext(DbContextOptions<ProtocolSystemDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Protocol> Protocols { get; set; }
    public DbSet<ProtocolStatus> ProtocolStatuses { get; set; }
    public DbSet<ProtocolFollow> ProtocolFollows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProtocolSystemDbContext).Assembly);
    }
}
