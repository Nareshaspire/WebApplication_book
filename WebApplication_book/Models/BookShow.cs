namespace WebApplication_book.Models
{
    public class BookShow
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public Genre Genre { get; set; }

        public decimal Rating { get; set; }

        public string GoodreadsURLS { get; set; }
    }
}
