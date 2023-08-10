using System.Collections.Generic;

namespace WebAppFlowerBouquet.SessionModels
{
    public class Cart: Dictionary<int, CartItem>
    {
        public void AddToCart(CartItem item)
        {
            int id = item.FlowerBouquet.FlowerBouquetId;
            if (this.ContainsKey(id))
            {

            }
            else
            {
            }
        }
    }
}
