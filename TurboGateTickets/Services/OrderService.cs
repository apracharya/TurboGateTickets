using Microsoft.EntityFrameworkCore;
using TurboGateTickets.Data;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;

namespace TurboGate.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDataContext context;

        public OrderService(AppDataContext context)
        {
            this.context = context;
        }

        public bool Add(Order order)
        {
            context.Add(order);
            return Save();
        }

        public Task<Order> CreateOrder(Order model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Order order)
        {
            context.Remove(order);
            return Save();
        }

        public Task<Order> DeleteOrder(Order model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> ReadAllOrders()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> ReadOrder(int id)
        {
            return await context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Order order)
        {
            context.Update(order);
            return Save();
        }

        public Task<Order> UpdateOrder(int id, Order model)
        {
            throw new NotImplementedException();
        }
    }
}
