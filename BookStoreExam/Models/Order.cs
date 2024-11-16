namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Coment { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public int OrderDetailsId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }     

    }
}
