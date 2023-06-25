using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.SignalR;
using FlowerBouquetManagementSystem.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<FlowerHub> _hubContext;

        public IndexModel(IHubContext<FlowerHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        public IList<Customer> Customer { get;set; }

        public void OnGet()
        {
            Customer = _customerRepository.GetCustomers();
        }
    }
}
