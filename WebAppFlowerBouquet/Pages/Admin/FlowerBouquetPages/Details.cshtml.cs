using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace WebAppFlowerBouquet.Pages.Admin.FlowerBouquetPages
{
    public class DetailsModel : PageModel
    {
        private FlowerBouquetRepository flowerBouquetRepository;

        public DetailsModel(FlowerBouquetRepository flowerBouquetRepository)
        {
            this.flowerBouquetRepository = flowerBouquetRepository;
        }

        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                // navigate to error page
                return NotFound();
            }

            FlowerBouquet = flowerBouquetRepository.Get(id.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
