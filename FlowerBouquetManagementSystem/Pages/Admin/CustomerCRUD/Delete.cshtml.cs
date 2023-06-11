using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public DeleteModel()
        {
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGetAsync(int? id)
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

        public IActionResult OnPost(int? id)
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

            _customerRepository.DeleteCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}
