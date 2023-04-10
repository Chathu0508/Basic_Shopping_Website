using System.Threading.Tasks;

namespace BackendApplication.Repositories
{
    public interface IUserOrderRespository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}