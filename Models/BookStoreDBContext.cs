
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE_DEMO.Models
{
    public class BookStoreDBContext:DbContext
    {
        public BookStoreDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAdress>().HasKey(ud => new
            {
                ud.UserId,
                ud.AddressId
            });


            modelBuilder.Entity<UserAdress>()
                .HasOne(m=>m.Address)
                .WithMany(m=>m.UserAdresses)
                .HasForeignKey(m=>m.AddressId);


            modelBuilder.Entity<UserAdress>()
                .HasOne(m => m.User)
                .WithMany(m => m.UserAdresses)
                .HasForeignKey(m => m.UserId);


            modelBuilder.Entity<OrderDetail>().HasKey(od => new
            {
                od.ShopOrderId,
                od.CartItemId
            });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(m => m.ShopOrder)
                .WithMany(m => m.OrderDetails)
                .HasForeignKey(m => m.ShopOrderId);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(m => m.CartItem)
                .WithMany(m => m.OrderDetails)
                .HasForeignKey(m => m.CartItemId);

            modelBuilder.Entity<Review>().HasKey(rv => new
            {
                rv.UserId,
                rv.BookId
            });

            modelBuilder.Entity<Review>()
                .HasOne(m => m.User)
                .WithMany(m => m.Reviews)
                .HasForeignKey(m => m.UserId);


            modelBuilder.Entity<Review>()
                .HasOne(m => m.Book)
                .WithMany(m => m.Reviews)
                .HasForeignKey(m => m.BookId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set;}
        public DbSet<Cart> Carts { get; set;}
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAdress> UserAdresses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShopOrder> ShopOrders  { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
