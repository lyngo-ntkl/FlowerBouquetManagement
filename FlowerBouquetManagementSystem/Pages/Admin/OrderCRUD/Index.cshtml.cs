using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class IndexModel : PageModel
    {
        private readonly OrderRepository _orderRepository;
        public IndexModel(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> Orders { get;set; }

        public void OnGet()
        {
            Orders = _orderRepository.GetAll();
        }
    }
}
