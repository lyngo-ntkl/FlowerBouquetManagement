using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class OrderDetailRepositoryImpl : OrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);

        public List<OrderDetail> FindOrderDetailByFlowerBouquetId(int flowerBouquetId) => OrderDetailDAO.FindOrderDetailByFlowerBouquetId(flowerBouquetId);

        public List<OrderDetail> FindOrderDetailByOrderId(int orderId) => OrderDetailDAO.FindOrderDetailByOrderId(orderId);

        public OrderDetail FindOrderDetailByOrderIdAndFlowerBouquetId(int orderId, int flowerBouquetId) => OrderDetailDAO.FindOrderDetailByOrderIdAndFlowerBouquetId(orderId, flowerBouquetId);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();

        public void SaveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
    }
}
