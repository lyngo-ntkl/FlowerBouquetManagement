using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderRepository
    {
        List<Order> GetOrders();
        Order FindOrderById(int id);
<<<<<<< HEAD
=======
        List<Order> FindOrderByCustomerId(int customerId);
        Order FindOrderByIdIncludeOrderDetails(int orderId);
        Order FindOrderByIdIncludeCustomer(int orderId);
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
