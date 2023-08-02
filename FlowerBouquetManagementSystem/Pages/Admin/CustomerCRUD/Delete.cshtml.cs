using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
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

            Customer = _customerRepository.GetAll().Where(x => x.CustomerId == id).SingleOrDefault();

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

            Customer = _customerRepository.GetAll().Where(x => x.CustomerId == id).SingleOrDefault();

            if (Customer == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }

            _customerRepository.Delete(Customer);

            return RedirectToPage("./Index");
        }
    }
}
