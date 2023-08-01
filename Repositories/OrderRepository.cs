using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface OrderRepository
    {
        List<Order> GetAll();
        Order Get(int id);
        void Save(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
