using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace FlowerBouquetManagementSystem.Pages.FlowerBouquetCRUD
{
    public class EditModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly CategoryRepository _categoryRepository = new CategoryRepositoryImpl();
        private readonly SupplierRepository _supplierRepository = new SupplierRepositoryImpl();

        public EditModel()
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
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetSuppliers(), "SupplierId", "SupplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            if(_flowerBouquetRepository.FindFlowerBouquetById(FlowerBouquet.FlowerBouquetId) == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            _flowerBouquetRepository.UpdateFlowerBouquet(FlowerBouquet);

            return RedirectToPage("./Index");
        }
    }
}
