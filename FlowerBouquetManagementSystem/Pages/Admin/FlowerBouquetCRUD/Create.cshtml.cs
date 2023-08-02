using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;

        public CreateModel(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, SupplierRepository supplierRepository, IHubContext<FlowerHub> hubContext)
        {
            _flowerHub = hubContext;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _flowerBouquetRepository = flowerBouquetRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryName"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierName"] = new SelectList(_supplierRepository.GetAll(), "SupplierId", "SupplierName");
            return Page();
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Create");
            }

            _flowerBouquetRepository.Save(FlowerBouquet);
            _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");

            return RedirectToPage("/Index");
        }
    }
}
