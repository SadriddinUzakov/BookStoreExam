namespace BookStore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDetails> OrdersD { get; set; }
    }
}
