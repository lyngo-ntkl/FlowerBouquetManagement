using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderRepository
    {
        List<Order> GetOrders();
        Order FindOrderById(int id);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
