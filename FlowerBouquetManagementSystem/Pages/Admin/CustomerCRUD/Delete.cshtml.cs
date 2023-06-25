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
    public class DeleteModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<CustomerHub> _hubContext;

        public DeleteModel(IHubContext<CustomerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGetAsync(int? customerId)
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

        public IActionResult OnPost(int? customerId)
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

            _customerRepository.DeleteCustomer(Customer);
            _hubContext.Clients.All.SendAsync("LoadCustomer");

            return RedirectToPage("./Index");
        }
    }
}
