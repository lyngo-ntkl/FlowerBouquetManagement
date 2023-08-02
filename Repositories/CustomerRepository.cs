using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface CustomerRepository
    {
        List<Customer> GetAll();
        Customer Get(int id);
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
