using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    internal interface CustomerRepository
    {
        List<Customer> GetCustomers();
        Customer FindCustomerById(int id);
        Customer FindCustomerByEmailAndPassword(string email, string password);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
