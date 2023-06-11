using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    public class CreateModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public CreateModel()
        {
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

            return RedirectToPage("/Login");
        }
    }
}
