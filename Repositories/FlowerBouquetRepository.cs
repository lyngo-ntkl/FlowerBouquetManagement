using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface FlowerBouquetRepository
    {
        List<FlowerBouquet> GetFlowerBouquets();
        //Task<List<FlowerBouquet>> GetFlowerBouquetsWithCategoryAndSupplier();
        List<FlowerBouquet> GetFlowerBouquetsWithCategoryAndSupplier();
        FlowerBouquet FindFlowerBouquetById(int id);
        FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplier(int id);
        List<FlowerBouquet> FindFlowerBouquetContainName(string name);
        void SaveFlowerBouquet(FlowerBouquet flowerBouquet);
        void UpdateFlowerBouquet(FlowerBouquet flowerBouquet);
        void DeleteFlowerBouquet(FlowerBouquet flowerBouquet);
    }
}
