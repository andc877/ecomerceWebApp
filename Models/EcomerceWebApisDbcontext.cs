using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Models
{
    public class EcomerceWebApisDbcontext : DbContext
    {
        public EcomerceWebApisDbcontext(DbContextOptions<EcomerceWebApisDbcontext> options) : base(options)
        {

        }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Analytics> Analytics { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Enquiries> Enquiries { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PlanPrice> PlanPrices { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PromotionCoupons> PromotionCoupons { get; set; }
        public DbSet<Refunds> Refunds { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Orders>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PlanPrice>()
                .Property(pp => pp.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Plans>()
                .Property(p => p.PlanPriceID)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ProductPrice>()
                .Property(pp => pp.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PromotionCoupons>()
                .Property(pc => pc.Discount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Refunds>()
                .Property(r => r.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Shipping>()
                .Property(s => s.ShippingCost)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transactions>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18, 2)");
        }

    }
}

