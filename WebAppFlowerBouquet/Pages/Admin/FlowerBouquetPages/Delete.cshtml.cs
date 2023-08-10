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
    public class DeleteModel : PageModel
    {
        private FlowerBouquetRepository flowerBouquetRepository;

        public DeleteModel(FlowerBouquetRepository flowerBouquetRepository)
        {
            this.flowerBouquetRepository = flowerBouquetRepository;
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBouquet = flowerBouquetRepository.Get(id.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBouquet = flowerBouquetRepository.Get(id.Value);

            if (FlowerBouquet != null)
            {
                flowerBouquetRepository.Delete(FlowerBouquet);
            }

            return RedirectToPage("./Index");
        }
    }
}
