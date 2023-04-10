using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public  IActionResult Dashbaord()
        {
            var applicationDbContext = (from or in _context.Orders
                                        join u in _context.Users on or.UserId equals u.Id
                                        join os in _context.orderStatuses on or.OrderStatusId equals os.Id
                                        select new OrdersDto()
                                        {
                                            Id = or.Id,
                                            CreateDate = or.CreateDate,
                                            Email = u.Email,
                                            IsDeleted = or.IsDeleted,
                                            OrderStatusId = or.OrderStatusId,
                                            UserId = u.Id,
                                            UserName = u.UserName,
                                            StatusName = os.StatusName
                                        }).ToList();


            var OrdersStatus = new DashboardDto();

            if(applicationDbContext.Count>0)
            {
                OrdersStatus.PendingOrders = applicationDbContext.FindAll(x=> x.StatusName == "Pending").Count();
                OrdersStatus.RetrunedOrders = applicationDbContext.FindAll(x => x.StatusName == "Retruned").Count();
                OrdersStatus.DeliveredOrders = applicationDbContext.FindAll(x => x.StatusName == "Delivered").Count();
                OrdersStatus.RefundOrders = applicationDbContext.FindAll(x => x.StatusName == "Refund").Count();
                OrdersStatus.ShippedOrders = applicationDbContext.FindAll(x => x.StatusName == "Shipped").Count();

            }
            return View(OrdersStatus);
        }
    }
}
