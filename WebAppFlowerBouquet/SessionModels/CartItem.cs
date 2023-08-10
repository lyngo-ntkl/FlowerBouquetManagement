using DTOs;

namespace WebAppFlowerBouquet.SessionModels
{
    public class CartItem
    {
        public FlowerBouquetDTO FlowerBouquet { get; set;}
        public int Quantity { get; set;}
    }
}
