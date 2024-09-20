using Microsoft.EntityFrameworkCore;

namespace MSJ_Enterprises.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Login> login { get; set; }

        public DbSet<Customers> customers { get; set; }

        public DbSet<Item> items { get; set; }

        public DbSet<SaleInvoice> invoices { get; set; }

        public DbSet<SaleItem> saleItems { get; set; }

        public DbSet<Bank> bank { get; set; }
        
        public DbSet<PurchaseItem> PurchaseItem { get; set; }

        public DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bank>()
                .HasOne(b => b.Customers)
                .WithMany(c => c.Bank)
                .HasForeignKey(b => b.CustomerId)
                .HasPrincipalKey(c => c.Cid);


            modelBuilder.Entity<SaleInvoice>()
                .HasMany(s => s.SaleItems)
                .WithOne(si => si.SaleInvoice)
                .HasForeignKey(si => si.ID);


            modelBuilder.Entity<SaleInvoice>()
                .HasOne(s => s.Customers)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);
            
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => si.ItemID);

            modelBuilder.Entity<PurchaseInvoice>()
                .HasMany(s => s.PurchaseItems)
                .WithOne(si => si.PurchaseInvoice)
                .HasForeignKey(si => si.ID);


            modelBuilder.Entity<PurchaseInvoice>()
                .HasOne(s => s.Customers)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<PurchaseItem>()
                .HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => si.ItemID);









            modelBuilder.Entity<Login>().HasData(
               new Login
               {
                   uid = 1,
                   Email = "muhammadsaadjunejo@gmail.com",
                   Password = "saadjunejo",
                   Role = "Admin",
                   Name = "Muhammad-Saad"
               }
            // Add more admin records if needed
            );


        }
    }
}
