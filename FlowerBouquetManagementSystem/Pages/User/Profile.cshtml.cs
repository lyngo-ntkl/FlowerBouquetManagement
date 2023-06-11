using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using System.Linq;

namespace FlowerBouquetManagementSystem.Pages.User
{
    [Authorize(Roles = "User")]
    public class ProfileModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public ProfileModel()
        {
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            var claims = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Sid)).Value;
            if (claims == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }

            Customer = _customerRepository.FindCustomerById(Int32.Parse(claims));

            if (Customer == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
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

            return RedirectToPage("./Index");
        }
    }
}
