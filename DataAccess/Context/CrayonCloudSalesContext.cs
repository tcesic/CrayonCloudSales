using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.Context
{
    public class CrayonCloudSalesContext : DbContext
    {
        public CrayonCloudSalesContext(DbContextOptions<CrayonCloudSalesContext> options) : base(options)
        {
        }


        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Software>? Softwares { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Customer>()
               .ToTable("Customer")
               .HasKey(c => c.Id);

            builder.Entity<Customer>()
               .Property(c => c.Name)
               .IsRequired();

            builder.Entity<Account>()
                .ToTable("Account")
                .HasKey(a => a.Id);

            builder.Entity<Account>()
                .Property(a => a.Name)
                .IsRequired();

            builder.Entity<Account>()
                .HasOne(b => b.Customer)
                .WithMany(a => a.Accounts)
                .HasForeignKey(b => b.CustomerId);

            builder.Entity<Software>()
                .ToTable("Software")
                .HasKey(c => c.Id);

            builder.Entity<Software>()
                .Property(s => s.Quantity)
                .IsRequired();

            builder.Entity<Software>()
                .Property(s => s.Name)
                .IsRequired();

            builder.Entity<Software>()
                .Property(s => s.State)
                .IsRequired();

            builder.Entity<Software>()
                .Property(s => s.State)
                .IsRequired();

            builder.Entity<Software>()
                .HasOne(s => s.Account)
                .WithMany(a => a.Softwares)
                .HasForeignKey(s => s.AccountId);


        }
    }
}