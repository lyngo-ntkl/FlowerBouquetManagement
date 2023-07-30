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
    public class EditModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<CustomerHub> _hubContext;

        public EditModel(IHubContext<CustomerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_customerRepository.FindCustomerById(Customer.CustomerId) == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }

            _customerRepository.UpdateCustomer(Customer);
            _hubContext.Clients.All.SendAsync("LoadCustomer");

            return RedirectToPage("./Index");
        }
    }
}
