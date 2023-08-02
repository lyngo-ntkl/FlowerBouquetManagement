using DTOs;

namespace FlowerBouquetManagementSystemWebApp.SessionModels
{
    public class CartItem
    {
        public FlowerBouquetDTO FlowerBouquetDTO { get; set; }
        public int Quantity { get; set; }
    }
}
