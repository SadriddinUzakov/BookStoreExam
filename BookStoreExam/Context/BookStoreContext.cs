using BookStore.Models;
using Microsoft.EntityFrameworkCore;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<About> About { get; set; }
    public DbSet<Adress> Adress { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetails> OrderD { get; set; }
    public DbSet<Report> Report { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Employees>Employees { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>();
    }
}
