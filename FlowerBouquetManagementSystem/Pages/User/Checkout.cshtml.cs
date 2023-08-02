using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FlowerBouquetManagementSystem.Pages.User
{
    [Authorize(Roles = "User")]
    public class CheckoutModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        public List<CartItem> Cart { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public void OnGet(List<CartItem> cart, decimal total)
        {
            Cart = cart;
            Total = total;
            var customerId = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Sid)).Value;
            Customer = _customerRepository.Get(Int32.Parse(customerId));
        }
    }
}
