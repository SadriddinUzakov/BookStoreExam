namespace BookStore.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<OrderDetails> OrdersD { get; set; }
    }
}
