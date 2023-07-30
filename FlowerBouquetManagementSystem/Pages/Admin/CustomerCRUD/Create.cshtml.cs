using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<CustomerHub> _hubContext;

        public CreateModel(IHubContext<CustomerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_customerRepository.FindCustomerByEmail(Customer.Email) != null)
            {
                ModelState.AddModelError("DuplicateEmail", Customer.Email + " has been registered");
                return Page();
            }

            _customerRepository.SaveCustomer(Customer);
            _hubContext.Clients.All.SendAsync("LoadCustomer");

            return RedirectToPage("/Login");
        }
    }
}
