using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Mvc;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class FlowerBouquetIndex : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private const string BuyAction = "Buy now";
        private const string AddToCartAction = "Add to Cart";

        public FlowerBouquetIndex()
        {
        }

        public IList<FlowerBouquet> FlowerBouquets { get;set; }
        public FlowerBouquet FlowerBouquet { get; set; }

        public void OnGet()
        {
            FlowerBouquets = _flowerBouquetRepository.GetFlowerBouquetsWithCategoryAndSupplier();
        }

        public IActionResult OnPost(string action)
        {
            if (BuyAction.Equals(action))
            {

            } else if (AddToCartAction.Equals(action))
            {

            }
            return Page();
        }
    }
}
