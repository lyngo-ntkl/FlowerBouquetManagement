﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace FlowerBouquetManagementSystem.Pages.OrderDetailCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFlowerBouquetManagementContext _context;

        public DeleteModel(BusinessObjects.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails
                .Include(o => o.FlowerBouquet)
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.OrderId == id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails.FindAsync(id);

            if (OrderDetail != null)
            {
                _context.OrderDetails.Remove(OrderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
