namespace BookStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrderDetails> OrdersD { get; set; }
        public virtual ICollection<Adress> Adress { get; set; }

    }
}
