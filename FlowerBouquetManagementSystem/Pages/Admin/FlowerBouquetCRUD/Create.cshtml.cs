using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    public class CreateModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly CategoryRepository _categoryRepository = new CategoryRepositoryImpl();
        private readonly SupplierRepository _supplierRepository = new SupplierRepositoryImpl();

        public CreateModel()
        {
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryName"] = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            ViewData["SupplierName"] = new SelectList(_supplierRepository.GetSuppliers(), "SupplierId", "SupplierName");
            return Page();
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _flowerBouquetRepository.SaveFlowerBouquet(FlowerBouquet);

            return RedirectToPage("./Index");
        }
    }
}
