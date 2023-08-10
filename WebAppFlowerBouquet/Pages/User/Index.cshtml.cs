using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using WebAppFlowerBouquet.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppFlowerBouquet.Pages.User
{
    public class IndexModel : PageModel
    {
        private FlowerBouquetRepository flowerBouquetRepository;
        private CategoryRepository categoryRepository;
        private SupplierRepository supplierRepository;

        public IndexModel(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, SupplierRepository supplierRepository)
        {
            this.flowerBouquetRepository = flowerBouquetRepository;
            this.categoryRepository = categoryRepository;
            this.supplierRepository = supplierRepository;
        }

        public PaginatedList<FlowerBouquet> FlowerBouquet { get; set; }
        public string Name { get; private set; }
        public byte Status { get; private set; }
        public int CategoryId { get; private set; }
        public int SupplierId { get; private set; }

        public void OnGet(string name, byte? status, int? categoryId, int? supplierId, int? pageSize, int? pageNumber)
        {
            var flowerBouquet = flowerBouquetRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
            {
                flowerBouquet = flowerBouquet.Where(x => x.FlowerBouquetName.ToLower().Contains(name.ToLower())).ToList();
                Name = name;
            }
            if (status != null)
            {
                flowerBouquet = flowerBouquet.Where(x => x.FlowerBouquetStatus == status).ToList();
                Status = status.Value;
            }
            if (categoryId != null)
            {
                flowerBouquet = flowerBouquet.Where(x => x.CategoryId == categoryId).ToList();
                CategoryId = categoryId.Value;
            }
            if (supplierId != null)
            {
                flowerBouquet = flowerBouquet.Where(x => x.SupplierId == supplierId).ToList();
                SupplierId = supplierId.Value;
            }
            ViewData["Categories"] = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName", $"{CategoryId}");
            ViewData["Suppliers"] = new SelectList(supplierRepository.GetAll(), "SupplierId", "SupplierName", $"{SupplierId}");
            FlowerBouquet = PaginatedList<FlowerBouquet>.ToPaginatedList(flowerBouquet, pageSize ?? 4, pageNumber ?? 1);
        }
    }
}
