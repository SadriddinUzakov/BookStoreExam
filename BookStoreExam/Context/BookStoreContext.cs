using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category>  Category { get;  set; }
    public DbSet<About>  About { get;  set; }
    public DbSet<Adress>  Adress { get;  set; }
    public DbSet<Author>  Author { get;  set; }
    public DbSet<Order>  Order { get;  set; }
    public DbSet<OrderDetails>  OrderD { get;  set; }
    public DbSet<Report>  Report { get;  set; }
    public DbSet<User>  User { get;  set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Server=localhost;Database=BookStore;User Id=postgres;Password=19871984;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>();
    }

   
}