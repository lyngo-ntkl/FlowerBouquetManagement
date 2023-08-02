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
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private const string BuyAction = "Buy now";
        private const string AddToCartAction = "Add to Cart";

        public FlowerBouquetIndex(FlowerBouquetRepository flowerBouquetRepository)
        {
            _flowerBouquetRepository = flowerBouquetRepository;
        }

        public IList<FlowerBouquet> FlowerBouquets { get;set; }
        public FlowerBouquet FlowerBouquet { get; set; }

        //public async void OnGetAsync()
        //{
        //    FlowerBouquets = await _flowerBouquetRepository.GetFlowerBouquetsWithCategoryAndSupplier();
        //}

        public void OnGet()
        {
            FlowerBouquets = _flowerBouquetRepository.GetAll();
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
