using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderRepository
    {
        List<Order> GetOrders();
        Order FindOrderById(int id);
        List<Order> FindOrderByCustomerId(int customerId);
        Order FindOrderByIdIncludeOrderDetails(int orderId);
        Order FindOrderByIdIncludeCustomer(int orderId);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
