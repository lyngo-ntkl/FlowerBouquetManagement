using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
<<<<<<< HEAD
    internal interface CustomerRepository
    {
        List<Customer> GetCustomers();
        Customer FindCustomerById(int id);
=======
    public interface CustomerRepository
    {
        List<Customer> GetCustomers();
        Customer FindCustomerById(int id);
        Customer FindCustomerByEmail(string email);
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        Customer FindCustomerByEmailAndPassword(string email, string password);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
