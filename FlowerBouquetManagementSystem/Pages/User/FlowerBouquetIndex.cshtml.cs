using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class FlowerBouquetIndex : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();

        public FlowerBouquetIndex()
        {
        }

        public IList<FlowerBouquet> FlowerBouquets { get;set; }
        public FlowerBouquet FlowerBouquet { get; set; }

        public void OnGet()
        {
            FlowerBouquets = _flowerBouquetRepository.GetFlowerBouquetsWithCategoryAndSupplier();
        }

        public void OnPost()
        {

        }
    }
}
