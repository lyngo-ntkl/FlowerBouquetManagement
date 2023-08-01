﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();

        public DetailsModel()
        {
        }

        public Customer Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }

            Customer = _customerRepository.FindCustomerById(id.Value);

            if (Customer == null)
            {
                ModelState.AddModelError("NotFound", "Customer not found");
                return Page();
            }
            return Page();
        }
    }
}