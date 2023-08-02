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
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;

        public EditModel(IHubContext<FlowerHub> hubContext, FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, SupplierRepository supplierRepository)
        {
            this._flowerHub = hubContext;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _flowerBouquetRepository = flowerBouquetRepository;
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            FlowerBouquet = _flowerBouquetRepository.Get(id.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_supplierRepository.GetAll(), "SupplierId", "SupplierName");
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

            if(_flowerBouquetRepository.Get(FlowerBouquet.FlowerBouquetId) == null)
            {
                return NotFound();
            }

            _flowerBouquetRepository.Update(FlowerBouquet);
            _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");

            return RedirectToPage("./Index");
        }
    }
}
