using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly IHubContext<FlowerHub> _flowerHub;

        public DeleteModel(IHubContext<FlowerHub> hubContext)
        {
            this._flowerHub = hubContext;
        }

        [BindProperty]
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

        public IActionResult OnPost(int? flowerBouquetId)
        {
            if (flowerBouquetId == null)
            {
                return NotFound();
            }

            FlowerBouquet = _flowerBouquetRepository.FindFlowerBouquetById(flowerBouquetId.Value);

            if (FlowerBouquet != null)
            {
                _flowerBouquetRepository.DeleteFlowerBouquet(FlowerBouquet);
                _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");
            } else
            {
                return NotFound();
            }

            return RedirectToPage("/Index");
        }
    }
}
