using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class OrderDetailRepositoryImpl : OrderDetailRepository
    {
        public void Delete(OrderDetail orderDetail) => OrderDetailDAO.Delete(orderDetail);

        public OrderDetail Get(int orderId, int flowerBouquetId) => OrderDetailDAO.Get(orderId, flowerBouquetId);

        public List<OrderDetail> GetAll() => OrderDetailDAO.GetAll();

        public void Save(OrderDetail orderDetail) => OrderDetailDAO.Save(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Update(orderDetail);
    }
}
