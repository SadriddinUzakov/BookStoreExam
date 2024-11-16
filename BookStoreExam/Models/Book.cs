namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

}
