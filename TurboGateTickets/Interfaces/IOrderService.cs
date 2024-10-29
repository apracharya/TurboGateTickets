using System.Collections;
using TurboGateTickets.Models;

namespace TurboGateTickets.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order model);
        Task<Order> UpdateOrder(int id, Order model);
        Task<Order> DeleteOrder(Order model);
        Task<Order> ReadOrder(int id);
        Task<IEnumerable<Order>> ReadAllOrders();
        bool Add(Order order);
        bool Update(Order order);
        bool Delete(Order order);
        bool Save();

    }
}
