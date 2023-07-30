using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using System.Security.Claims;
using System.Linq;
using System;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class OrderHistoryModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        public OrderHistoryModel()
        {
        }

        public IList<Order> Orders { get;set; }

        public void OnGet()
        {
            var claims = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Sid)).Value;

            Orders = _orderRepository.FindOrderByCustomerId(Int32.Parse(claims));
        }
    }
}
