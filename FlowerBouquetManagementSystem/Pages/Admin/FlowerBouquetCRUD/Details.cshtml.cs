using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly IHubContext<FlowerHub> _flowerHub;

        public DetailsModel(IHubContext<FlowerHub> hubContext)
        {
            _flowerHub = hubContext;
        }

        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? flowerBouquetId)
        {
            if (flowerBouquetId == null)
            {
                return NotFound();
            }

            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetsByIdWithCategoryAndSupplier(flowerBouquetId.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
