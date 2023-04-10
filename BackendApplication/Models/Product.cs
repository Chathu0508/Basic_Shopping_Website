namespace BackendApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string? AuthorName { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
    }
}
