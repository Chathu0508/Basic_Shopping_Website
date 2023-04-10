namespace BackendApplication.Models.DTOs
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int OrderStatusId { get; set; }
        public string? StatusName { get; set; }


    }
}
