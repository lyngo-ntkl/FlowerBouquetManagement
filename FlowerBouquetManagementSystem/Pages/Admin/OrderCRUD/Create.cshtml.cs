using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class CreateModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public CreateModel()
        {
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetCustomers(), "CustomerId", "CustomerName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderRepository.SaveOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
