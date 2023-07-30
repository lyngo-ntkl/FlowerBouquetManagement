using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();

        public DeleteModel()
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
            return Page();
        }

        public IActionResult OnPost(int? id)
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

            _orderRepository.DeleteOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
