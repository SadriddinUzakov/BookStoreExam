namespace BookStore.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Bookcount {  get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
