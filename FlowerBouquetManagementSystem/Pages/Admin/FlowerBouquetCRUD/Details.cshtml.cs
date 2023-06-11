using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();

        public DetailsModel()
        {
        }

        public FlowerBouquet FlowerBouquet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }

            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetsByIdWithCategoryAndSupplier(id == null ? 0 : id.Value);

            if (FlowerBouquet == null)
            {
                ModelState.AddModelError("NotFound", "Flower bouquet not found");
                return Page();
            }
            return Page();
        }
    }
}
