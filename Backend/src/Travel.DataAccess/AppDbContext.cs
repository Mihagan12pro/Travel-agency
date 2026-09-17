using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.Model;
using Travel.Model.Contracts;
using Travel.Model.Staff;

namespace Travel.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<StaffUser> Users { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<ClientBTC> BTCClients { get; set; }

    public DbSet<PrimaryAgreement> PrimaryAgreements { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StaffUser>()
            .HasOne<Employee>()
            .WithOne()
            .HasForeignKey<StaffUser>(u => u.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StaffUser>()
           .HasIndex(u => u.Login)
           .IsUnique();


        modelBuilder.Entity<PrimaryAgreement>()
            .HasOne<StaffUser>()
            .WithMany()
            .HasForeignKey(pa => pa.StaffUserId);

        modelBuilder.Entity<PrimaryAgreement>()
            .HasOne<ClientBTC>()
            .WithMany()
            .HasForeignKey(pa => pa.ClientId);


        modelBuilder.Entity<Contract>()
            .HasOne<StaffUser>()
            .WithMany()
            .HasForeignKey(pa => pa.StaffUserId);

        modelBuilder.Entity<PrimaryAgreement>()
            .HasOne<Contract>()
            .WithOne()
            .HasForeignKey<Contract>(c => c.AgreementId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}