﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;

namespace FlowerBouquetManagementSystem.Pages.FlowerBouquetCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();

        public DeleteModel()
        {
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetsByIdWithCategoryAndSupplier(id == null ? 0 : id.Value);

            if (FlowerBouquet == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetById(id == null ? 0 : id.Value);

            if (FlowerBouquet != null)
            {
                _flowerBouquetRepository.DeleteFlowerBouquet(FlowerBouquet);
            } else
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
