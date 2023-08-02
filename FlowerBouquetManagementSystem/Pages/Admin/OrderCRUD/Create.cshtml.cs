using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using System.Linq;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class CreateModel : PageModel
    {
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;

        public CreateModel(OrderRepository orderRepository, CustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "Customer Email", "Email");
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

            _orderRepository.Save(Order);

            return RedirectToPage("./Index");
        }
    }
}
