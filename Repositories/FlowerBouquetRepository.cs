using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface FlowerBouquetRepository
    {
        List<FlowerBouquet> GetFlowerBouquets();
        List<FlowerBouquet> GetFlowerBouquetsWithCategoryAndSupplier();
        FlowerBouquet FindFlowerBouquetById(int id);
        FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplier(int id);
        List<FlowerBouquet> FindFlowerBouquetContainName(string name);
        void SaveFlowerBouquet(FlowerBouquet flowerBouquet);
        void UpdateFlowerBouquet(FlowerBouquet flowerBouquet);
        void DeleteFlowerBouquet(FlowerBouquet flowerBouquet);
        FlowerBouquet GetFlowerBouquetWithTheLargestId();
    }
}
