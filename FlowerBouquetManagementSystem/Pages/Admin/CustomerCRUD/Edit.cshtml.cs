using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public EditModel()
        {
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }

            Customer = _customerRepository.FindCustomerById(id.Value);

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
