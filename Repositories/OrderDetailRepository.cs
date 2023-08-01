using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderDetailRepository
    {
        List<OrderDetail> GetAll();  
        OrderDetail Get(int orderId, int flowerBouquetId);
        void Save(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
    }
}
