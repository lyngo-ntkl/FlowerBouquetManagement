using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace FlowerBouquetManagementSystem.Pages.OrderDetailCRUD
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFlowerBouquetManagementContext _context;

        public IndexModel(BusinessObjects.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; }

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetails
                .Include(o => o.FlowerBouquet)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
