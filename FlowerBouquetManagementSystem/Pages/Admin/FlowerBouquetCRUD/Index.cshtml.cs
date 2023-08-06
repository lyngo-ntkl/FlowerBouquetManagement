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

namespace FlowerBouquetManagementSystemWebApp.Pages.Admin.FlowerBouquetCRUD
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;

        public IndexModel(IHubContext<FlowerHub> flowerHub, FlowerBouquetRepository flowerBouquetRepository)
        {
            _flowerHub = flowerHub;
            _flowerBouquetRepository = flowerBouquetRepository;
        }

        public IList<FlowerBouquet> FlowerBouquets { get; set; }

        public IActionResult OnGetFlowerBouquets()
        {
            FlowerBouquets = _flowerBouquetRepository.GetAll();
            return new JsonResult(_flowerBouquetRepository.GetAll());
        }
    }
}
