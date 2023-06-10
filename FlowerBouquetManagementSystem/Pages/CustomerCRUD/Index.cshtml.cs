using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.CustomerCRUD
{
    public class IndexModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public IndexModel()
        {
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = _customerRepository.GetCustomers();
        }
    }
}
