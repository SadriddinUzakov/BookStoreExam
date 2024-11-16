namespace BookStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get;set; }

        public int CategoryId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
    }
}

