using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        Store214089435Context _store214089435;

        public OrderRepository(Store214089435Context store214104465)
        {
            this._store214089435 = store214104465;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _store214089435.Orders.AddAsync(order);
            await _store214089435.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _store214089435.Orders.FindAsync(id);
        }
    }
}
