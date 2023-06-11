using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    public class IndexModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public IndexModel()
        {
        }

        public IList<Customer> Customer { get;set; }

        public void OnGet()
        {
            Customer = _customerRepository.GetCustomers();
        }
    }
}
