using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.OrderCRUD
{
    public class IndexModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        public IndexModel()
        {
        }

        public IList<Order> Orders { get;set; }

        public void OnGet()
        {
            Orders = _orderRepository.GetOrders();
        }
    }
}
