using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackendApplication.Repositories
{
    public class UserOrderRespository : IUserOrderRespository
    {
        private ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;




        public UserOrderRespository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,UserManager<IdentityUser> userManager)
        { 
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }

        public async Task<IEnumerable<Order>> UserOrders()
        {
            //var userId = GetUserID();
            //if (string.IsNullOrEmpty(userId))
            //    throw new Exception("User is not Logged-in");
            //var orders = _db.Orders
            //    .Include(x=>x.OrderDetail)
            //    .ThenInclude(x=>x.Book)
            //    .ThenInclude(x=>x.Genre)
            //    .Where(a=>a.UserId==userId)
            //    .ToListAsync();
            //return orders;
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User is not logged-in");
            var orders = await _db.Orders
                            .Include(x => x.OrderStatus)
                            .Include(x => x.OrderDetail)
                            .ThenInclude(x => x.Book)
                            .ThenInclude(x => x.Genre)
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
            return orders;

        }

        private string GetUserId()
        {
            var principle = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principle);
            return userId;
        }
    }
}
