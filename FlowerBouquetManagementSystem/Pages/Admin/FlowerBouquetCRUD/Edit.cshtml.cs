using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly CategoryRepository _categoryRepository = new CategoryRepositoryImpl();
        private readonly SupplierRepository _supplierRepository = new SupplierRepositoryImpl();
        private readonly IHubContext<FlowerHub> _flowerHub;

        public EditModel(IHubContext<FlowerHub> hubContext)
        {
            this._flowerHub = hubContext;
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? flowerBouquetId)
        {
            if (flowerBouquetId == null)
            {
                return NotFound();
            }
            
            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetsByIdWithCategoryAndSupplier(flowerBouquetId.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
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
                return RedirectToPage("./Edit");
            }

            if(_flowerBouquetRepository.FindFlowerBouquetById(FlowerBouquet.FlowerBouquetId) == null)
            {
                return NotFound();
            }

            _flowerBouquetRepository.UpdateFlowerBouquet(FlowerBouquet);
            _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");

            return RedirectToPage("/Index");
        }
    }
}
