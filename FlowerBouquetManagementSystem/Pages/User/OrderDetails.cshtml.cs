using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using System.Collections.Generic;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class OrderDetailsModel : PageModel
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailsModel(OrderRepository orderRepository, OrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
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
