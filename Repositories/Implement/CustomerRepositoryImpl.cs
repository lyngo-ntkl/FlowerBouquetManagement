using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class CustomerRepositoryImpl : CustomerRepository
    {
        public void Delete(Customer customer) => CustomerDAO.Delete(customer);

        public Customer Get(int id) => CustomerDAO.Get(id);

        public List<Customer> GetAll() => CustomerDAO.GetAll();

        public void Save(Customer customer) => CustomerDAO.Save(customer);

        public void Update(Customer customer) => CustomerDAO.Update(customer);
    }
}
