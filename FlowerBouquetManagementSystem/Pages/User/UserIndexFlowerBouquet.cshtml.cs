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
using FlowerBouquetManagementSystemWebApp.SessionModels;
using System.Linq;
using FlowerBouquetManagementSystemWebApp.Helper;
using AutoMapper;
using DTOs;

namespace FlowerBouquetManagementSystemWebApp.Pages.User
{
    //[Authorize(Roles = "User")]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class UserIndexFlowerBouquet : PageModel
    {
        private readonly FlowerBouquetRepository _flowerBouquetRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IHubContext<FlowerHub> _flowerHub;
        private readonly IMapper _mapper;

        public UserIndexFlowerBouquet(FlowerBouquetRepository flowerBouquetRepository, CategoryRepository categoryRepository, IHubContext<FlowerHub> flowerHub, IMapper mapper)
        {
            _flowerHub = flowerHub;
            _flowerBouquetRepository = flowerBouquetRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public PaginatedList<FlowerBouquet> FlowerBouquets { get; set; }
        public SelectList Categories { get; set; }

        // search by name, id (for admin only), category, sort by date
        public async Task<IActionResult> OnGetFlowerBouquets(string name, int? id, int? categoryId, int? pageNumber, int? pageSize)
        {
            Categories = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
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
            // Nope, json mark some value that it take before as $refs => so how I could take the object of $refs
            // Nah, the more simple way, change JsonSerializerOptions.ReferenceHandler. Well I assume that if I don't give it value, no more circular reference
            // if I use it json will have $id, $value & $ref
            await _flowerHub.Clients.All.SendAsync("LoadFlowerBouquet");
            return new JsonResult(FlowerBouquets);
        }

        public void OnPostAddCart(int id, int? quantity)
        {
            // haven't check condition
            var cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "Cart");
            if(cart == null)
            {
                cart = new Cart();
            }
            if (cart.ContainsKey(id))
            {
                var cartItem = cart[id];
                cartItem.Quantity = quantity == null ? cartItem.Quantity + 1 : cartItem.Quantity + quantity.Value;
                cart.AddToCart(cartItem);
            } else
            {
                var flowerBouquet = _flowerBouquetRepository.Get(id);
                cart.AddToCart(new CartItem()
                {
                    Quantity = quantity ?? 1,
                    FlowerBouquetDTO = _mapper.Map<FlowerBouquetDTO>(flowerBouquet)
                });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cart);
        }
    }
}
