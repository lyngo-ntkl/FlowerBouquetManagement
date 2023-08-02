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
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;

        public DeleteModel(IHubContext<FlowerHub> hubContext, FlowerBouquetRepository flowerBouquetRepository)
        {
            this._flowerHub = hubContext;
            _flowerBouquetRepository = flowerBouquetRepository;
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }

        public IActionResult OnGet(int? flowerBouquetId)
        {
            if (flowerBouquetId == null)
            {
                return NotFound();
            }

            FlowerBouquet = _flowerBouquetRepository.Get(flowerBouquetId.Value);

            if (FlowerBouquet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBouquet = _flowerBouquetRepository.Get(id.Value);

            if (FlowerBouquet != null)
            {
                _flowerBouquetRepository.Delete(FlowerBouquet);
                _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");
            } else
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
