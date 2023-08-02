using System.Collections.Generic;

namespace FlowerBouquetManagementSystemWebApp.SessionModels
{
    public class Cart: Dictionary<int, CartItem>
    {
        public Cart AddToCart(CartItem item)
        {
            int id = item.FlowerBouquetDTO.FlowerBouquetId;
            if (this.ContainsKey(id))
            {
                item.Quantity += this[id].Quantity;
                this.Add(id, item);
            }
            else
            {
                this.Add(id, item);
            }
            return this;
        }

        public void RemoveFromCart(int itemId)
        {
            if(this.ContainsKey(itemId))
            {
                this.Remove(itemId);
            }
        }
    }
}
