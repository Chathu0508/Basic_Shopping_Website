namespace BackendApplication.Models.DTOs
{
    public class DashboardDto
    {
        public int PendingOrders { get; set; }
        public int ShippedOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int RetrunedOrders { get; set; }
        public int RefundOrders { get; set; }

    }

}
