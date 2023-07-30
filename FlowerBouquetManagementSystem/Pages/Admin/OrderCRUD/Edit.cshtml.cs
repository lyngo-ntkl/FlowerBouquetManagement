using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class EditModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public EditModel()
        {
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Order not found");
                return Page();
            }

            Order = _orderRepository.FindOrderById(id.Value);

            if (Order == null)
            {
                ModelState.AddModelError("NotFound", "Order not found");
                return Page();
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetCustomers(), "CustomerId", "CustomerName");
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

            if(_orderRepository.FindOrderById(Order.OrderId) == null)
            {
                ModelState.AddModelError("NotFound", "Order not found");
                return Page();
            }

            _orderRepository.UpdateOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
