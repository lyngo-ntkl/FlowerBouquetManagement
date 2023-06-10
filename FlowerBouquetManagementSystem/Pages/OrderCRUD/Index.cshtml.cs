using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.OrderCRUD
{
    public class IndexModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        public IndexModel()
        {
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = _orderRepository.GetOrders();
        }
    }
}
