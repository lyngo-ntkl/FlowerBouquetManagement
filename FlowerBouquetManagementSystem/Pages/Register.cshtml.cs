using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.SignalR;
using FlowerBouquetManagementSystem.SignalR;

namespace FlowerBouquetManagementSystem.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        private readonly IHubContext<CustomerHub> _hubContext; 

        public RegisterModel(IHubContext<CustomerHub> hubContext)
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
