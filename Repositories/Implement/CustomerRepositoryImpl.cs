using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class CustomerRepositoryImpl : CustomerRepository
    {
        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);

        public Customer FindCustomerByEmailAndPassword(string email, string password) => CustomerDAO.FindCustomerByEmailAndPassword(email, password);

        public Customer FindCustomerById(int id) => CustomerDAO.FindCustomerById(id);

        public Customer FindCustomerByEmail(string email) => CustomerDAO.FindCustomerByEmail(email);

        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();

        public void SaveCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
    }
}
