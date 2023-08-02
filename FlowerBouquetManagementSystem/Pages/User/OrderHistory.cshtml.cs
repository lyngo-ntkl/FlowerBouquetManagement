using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using System.Security.Claims;
using System.Linq;
using System;
using FlowerBouquetManagementSystemWebApp.Helper;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class OrderHistoryModel : PageModel
    {
        private readonly OrderRepository _orderRepository = new OrderRepositoryImpl();
        public OrderHistoryModel()
        {
        }

        public PaginatedList<Order> Orders { get;set; }

        public void OnGet(int? pageNumber, int? pageSize)
        {
            var customerId = User.Claims.FirstOrDefault(x => x.Equals(ClaimTypes.Sid)).Value;
            var orders = _orderRepository.GetAll().Where(x => x.CustomerId.Equals(customerId));
            Orders = PaginatedList<Order>.ToPagedList(orders, pageNumber ?? 1, pageSize ?? 10);
        }
    }
}
