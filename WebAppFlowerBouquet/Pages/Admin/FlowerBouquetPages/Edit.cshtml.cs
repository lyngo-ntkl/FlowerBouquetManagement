using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using AutoMapper;
using DTOs;

namespace WebAppFlowerBouquet.Pages.Admin.FlowerBouquetPages
{
    public class EditModel : PageModel
    {
        private FlowerBouquetRepository flowerBouquetRepository;
        private CategoryRepository categoryRepository;
        private SupplierRepository supplierRepository;
        private IMapper mapper;

        public EditModel(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, SupplierRepository supplierRepository, IMapper mapper)
        {
            this.flowerBouquetRepository = flowerBouquetRepository;
            this.categoryRepository = categoryRepository;
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public FlowerBouquetDTO FlowerBouquet { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerBouquet = flowerBouquetRepository.Get(id.Value);

            if (flowerBouquet == null)
            {
                return NotFound();
            }
            FlowerBouquet = mapper.Map<FlowerBouquetDTO>(flowerBouquet);
            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(categoryRepository.GetAll(), "SupplierId", "SupplierId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }

            if(flowerBouquetRepository.Get(FlowerBouquet.FlowerBouquetId)  == null)
            {

            }

            flowerBouquetRepository.Update(mapper.Map<FlowerBouquet>(FlowerBouquet));

            return RedirectToPage("./Index");
        }
    }
}
