using BusProject.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Buss> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Ride> Rides { get; set; }
    public DbSet<Holidays> Holidays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-14U1OMS;Initial Catalog=Bus;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>()
            .HasMany(p => p.Students)
            .WithOne(s => s.Parent)
            .HasForeignKey(s => s.ParentId);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassId);

        modelBuilder.Entity<Ride>()
            .HasMany(r => r.Students)
            .WithOne(s => s.Ride)
            .HasForeignKey(s => s.RideId);

        modelBuilder.Entity<Buss>()
            .HasMany(b => b.Drivers)
            .WithOne(d => d.Bus)
            .HasForeignKey(d => d.BusId);

        modelBuilder.Entity<Driver>()
            .HasMany(d => d.Rides)
            .WithOne(r => r.Driver)
            .HasForeignKey(r => r.DriverId);
        modelBuilder.Entity<Holidays>()
            .HasNoKey();

        modelBuilder.Entity<Student>()
            .HasOne(s=>s.Parent)
            .WithMany(p => p.Students)
            .HasForeignKey(s=>s.ParentId);

        modelBuilder.Entity<Student>()
    .HasOne(s => s.Class)
    .WithMany(p => p.Students)
    .HasForeignKey(s => s.ClassId);

        modelBuilder.Entity<Student>()
    .HasOne(s => s.Ride)
    .WithMany(p => p.Students)
    .HasForeignKey(s => s.RideId);
    }
}
