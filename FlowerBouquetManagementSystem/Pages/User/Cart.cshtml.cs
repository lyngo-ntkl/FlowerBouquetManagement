using BusinessObjects.Models;
using FlowerBouquetManagementSystem.Pages.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using Repositories.Implement;
using System.Collections.Generic;
using System.Linq;

namespace FlowerBouquetManagementSystem.Pages.User
{
    public class CartModel : PageModel
    {
        private FlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepositoryImpl();
        public List<CartItem> Cart { get; set; }
        public decimal Total { get; set; }
        public void OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            if (Cart != null)
            {
                Total = 0;
                Cart.ForEach(cart => {
                    Total += cart.FlowerBouquet.UnitsInStock * (decimal)cart.Quantity;
                });
            }
        }

        public IActionResult OnGetBuyNow(int id)
        {
            var flowerBouquet = _flowerBouquetRepository.FindFlowerBouquetById(id);
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            if (Cart == null)
            {
                Cart = new List<CartItem>
                {
                    new CartItem()
                    {
                        FlowerBouquet = flowerBouquet,
                        Quantity = 1
                    }
                };
            }
            else
            {
                int index = IsCartItemExisted(id);
                if (index == -1)
                {
                    Cart.Add(new CartItem()
                    {
                        FlowerBouquet = flowerBouquet,
                        Quantity = 1
                    });
                }
                else
                {
                    Cart[index].Quantity++;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);

            return RedirectToPage("./Cart");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            var flowerBouquet = _flowerBouquetRepository.FindFlowerBouquetById(id);
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            if (Cart == null)
            {
                Cart = new List<CartItem>
                {
                    new CartItem()
                    {
                        FlowerBouquet = flowerBouquet,
                        Quantity = 1
                    }
                };
            }
            else
            {
                int index = IsCartItemExisted(id);
                if (index == -1)
                {
                    Cart.Add(new CartItem()
                    {
                        FlowerBouquet = flowerBouquet,
                        Quantity = 1
                    });
                }
                else
                {
                    Cart[index].Quantity++;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);

            return RedirectToPage("./FlowerBouquetIndex");
        }

        public IActionResult OnGetDelete(int id)
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            int index = IsCartItemExisted(id);
            if(index != -1)
            {
                Cart.RemoveAt(index);
                if (!Cart.Any())
                {
                    Cart = null;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);
            return RedirectToPage("./Cart");
        }

        public IActionResult OnPostUpdate(int quantity, int id)
        {
            Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            int index = IsCartItemExisted(id);
            if (index != -1)
            {
                Cart[index].Quantity += quantity;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);
            return RedirectToPage("./Cart");
        }

        private int IsCartItemExisted(int id)
        {
            int cartLength = Cart.Count;
            for (var i = 0; i < cartLength; i++) 
            {
                if (Cart[i].FlowerBouquet.FlowerBouquetId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public class CartItem
    {
        public FlowerBouquet FlowerBouquet { get; set; }
        public int Quantity { get; set; }
    }
}
