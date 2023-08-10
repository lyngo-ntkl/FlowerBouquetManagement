using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
using DTOs;
using BusinessObjects.Models;
using AutoMapper;

namespace WebAppFlowerBouquet.Pages.Admin.FlowerBouquetPages
{
    public class CreateModel : PageModel
    {
        private FlowerBouquetRepository flowerBouquetRepository;
        private CategoryRepository categoryRepository;
        private SupplierRepository supplierRepository;
        private IMapper mapper;

        public CreateModel(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, SupplierRepository supplierRepository, IMapper mapper)
        {
            this.flowerBouquetRepository = flowerBouquetRepository;
            this.categoryRepository = categoryRepository;
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(supplierRepository.GetAll(), "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public FlowerBouquetDTO FlowerBouquet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }

            flowerBouquetRepository.Save(mapper.Map<FlowerBouquet>(FlowerBouquet));

            return RedirectToPage("./Index");
        }
    }
}
