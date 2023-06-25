using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<CustomerHub> _hubContext;

        public DetailsModel(IHubContext<CustomerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Customer Customer { get; set; }

        public IActionResult OnGet(int? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            Customer = _customerRepository.FindCustomerById(customerId.Value);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
