using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class OrderRepositoryImpl : OrderRepository
    {
        public void Delete(Order order) => OrderDAO.Delete(order);

        public Order Get(int id) => OrderDAO.Get(id);

        public List<Order> GetAll() => OrderDAO.GetAll();

        public void Save(Order order) => OrderDAO.Save(order);

        public void Update(Order order) => OrderDAO.Update(order);
    }
}
