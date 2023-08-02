using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Linq;
using FlowerBouquetManagementSystemWebApp.Helper;

namespace FlowerBouquetManagementSystemWebApp.Pages.User
{
    //[Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;

        public IndexModel(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, IHubContext<FlowerHub> flowerHub)
        {
            _flowerHub = flowerHub;
            _flowerBouquetRepository = flowerBouquetRepository;
            _categoryRepository = categoryRepository;
        }

        public PaginatedList<FlowerBouquet> FlowerBouquets { get; set; }

        // search by name, id (for admin only), category, sort by date
        public IActionResult OnGetFlowerBouquets(string name, int? id, int? categoryId, int? pageNumber, int? pageSize)
        {
            ViewData["Categories"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            var flowerBouquets = _flowerBouquetRepository.GetAll().Where(x => x.FlowerBouquetStatus.Value == FlowerBouquetStatus.Available);

            if (id != null)
            {
                flowerBouquets = flowerBouquets.Where(x => x.FlowerBouquetId == id).ToList();
            }
            if (name != null)
            {
                flowerBouquets = flowerBouquets.Where(x => x.FlowerBouquetName.Contains(name)).ToList();
            }
            if (categoryId != null)
            {
                flowerBouquets = flowerBouquets.Where(x => x.CategoryId == categoryId).ToList();
            }
            // a simple version of pagination => to use it like generic, I will create a new class
            // FlowerBouquets.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            FlowerBouquets = PaginatedList<FlowerBouquet>.ToPagedList(flowerBouquets, pageNumber ?? 1, pageSize ?? 5);
            // I don't know whether the number of data transfer or serialize is limited?
            // cause every time I take Flower Bouquet with category & supplier, it will appear as undefine in some row
            var jsonResult = new JsonResult(FlowerBouquets
                //, new JsonSerializerOptions()
            //{
                //MaxDepth = 64
                //DefaultBufferSize = int.MaxValue,
            //}
                );
            return jsonResult;
        }

        public void OnPostAddCart(int id)
        {
            
        }
    }
}
