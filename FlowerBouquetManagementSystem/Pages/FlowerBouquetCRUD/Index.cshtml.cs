using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.FlowerBouquetCRUD
{
    public class IndexModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();

        public IndexModel()
        {
        }

        public IList<FlowerBouquet> FlowerBouquets { get;set; }

        public void OnGet()
        {
            FlowerBouquets = _flowerBouquetRepository.GetFlowerBouquetsWithCategoryAndSupplier();
        }
    }
}
