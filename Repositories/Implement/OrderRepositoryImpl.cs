using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class OrderRepositoryImpl : OrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);

        public Order FindOrderById(int id) => OrderDAO.FindOrderById(id);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public void SaveOrder(Order order) => OrderDAO.SaveOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);
    }
}
