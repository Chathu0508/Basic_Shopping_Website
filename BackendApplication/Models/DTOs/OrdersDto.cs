namespace BackendApplication.Models.DTOs
{
    public class OrdersDto
    {
        public int Id { get; set; }       
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? StatusName { get; set; }
    }
}
