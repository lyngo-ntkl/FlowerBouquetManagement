using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
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
