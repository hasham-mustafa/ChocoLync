using Microsoft.EntityFrameworkCore;
using ChocoLync.Models;

namespace ChocoLync.Data
{
    // We inherit from DbContext, which is a built-in .NET class that handles database work.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Each 'DbSet' here represents a table that will be created in SQL Server.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; } 
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Replacement> Replacements { get; set; }

        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sale>()
    .HasOne(x => x.Employee)
    .WithMany()
    .HasForeignKey(x => x.EmployeeId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Replacement>()
    .HasOne(x => x.OriginalProduct)
    .WithMany()
    .HasForeignKey(x => x.OriginalProductId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Replacement>()
    .HasOne(x => x.ReplacementProduct)
    .WithMany()
    .HasForeignKey(x => x.ReplacementProductId)
    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}