namespace BookStore.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Statuss {  get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
