namespace BookStore.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
