using AdvancedRepository.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FatDetail>().HasKey(f => new
            {
                f.Id,
                f.ProductId
            });
            modelBuilder.Entity<BasketDetail>().HasKey(f => new
            {
                f.Id,
                f.ProductId
            });
        }  
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<FatDetail> FatDetails { get; set; }
        public DbSet<FatMaster> FatMasters { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BasketMaster> BasketMasters { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
    }
}
 