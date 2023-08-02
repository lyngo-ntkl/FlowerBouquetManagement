using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using System.Collections.Generic;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        private readonly OrderDetailRepository _orderDetailRepository = new OrderDetailRepositoryImpl();

        public DetailsModel()
        {
        }

        public Order Order { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Order not found");
                return Page();
            }

            Order = _orderRepository.Get(id.Value);

            if (Order == null)
            {
                ModelState.AddModelError("NotFound", "Order not found");
                return Page();
            }

            //OrderDetails = _orderDetailRepository.FindOrderDetailByOrderId(id.Value);

            return Page();
        }
    }
}
