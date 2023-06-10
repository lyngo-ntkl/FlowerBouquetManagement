using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public RegisterModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_customerRepository.FindCustomerByEmail(Customer.Email) != null)
            {
                ModelState.AddModelError("DuplicateEmail", Customer.Email + " has been registered");
                return Page();
            }

            _customerRepository.SaveCustomer(Customer);

            return RedirectToPage("/Login");
        }
    }
}
