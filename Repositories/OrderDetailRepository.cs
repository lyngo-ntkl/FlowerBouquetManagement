using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();  
        OrderDetail FindOrderDetailByOrderIdAndFlowerBouquetId(int orderId, int flowerBouquetId);
        List<OrderDetail> FindOrderDetailByOrderId(int orderId);
        List<OrderDetail> FindOrderDetailByFlowerBouquetId(int flowerBouquetId);
        void SaveOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
