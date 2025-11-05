using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MedicalMixingERP.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // تعريف جميع الـ DbSet لكل جدول Model أنشأناه (لابد أن تمر على جميع الملفات)
        public DbSet<Client> Clients { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RawItem> RawItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<CompositionRawItem> CompositionRawItems { get; set; }
        public DbSet<PackingTransaction> PackingTransactions { get; set; }
        public DbSet<SupplierCustomer> SupplierCustomers { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<ShippingTransaction> ShippingTransactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<SalesRep> SalesReps { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }

        // إعداد العلاقات الخاصة إن وجدت
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // مثال: علاقة متعدد لمتعدد بين Composition وRawItem عبر CompositionRawItem
            modelBuilder.Entity<CompositionRawItem>()
                .HasKey(y => y.Id);
        }
    }
}
