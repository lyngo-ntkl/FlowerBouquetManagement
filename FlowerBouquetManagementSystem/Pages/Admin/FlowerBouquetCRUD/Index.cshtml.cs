using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Text.Json;

namespace FlowerBouquetManagementSystem.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        private readonly IHubContext<FlowerHub> _flowerHub;

        public IndexModel(IHubContext<FlowerHub> flowerHub)
        {
            _flowerHub = flowerHub;
        }

        public IList<FlowerBouquet> FlowerBouquets { get; set; }

        public IActionResult OnGetFlowerBouquets()
        {
            //FlowerBouquets = _flowerBouquetRepository.GetFlowerBouquets();
            FlowerBouquets = _flowerBouquetRepository.GetFlowerBouquetsWithCategoryAndSupplier();
            //var a = new JsonResult(FlowerBouquets);
            //var b = a.ToString();
            //return a;
            //var a = JsonSerializer.Serialize(FlowerBouquets);
            //return a;
            return new JsonResult(_flowerBouquetRepository.GetFlowerBouquets());
            //return new OkObjectResult(FlowerBouquets);
        }
    }
}
