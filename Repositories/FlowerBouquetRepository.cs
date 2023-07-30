using BusinessObjects.Models;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

namespace Repositories
{
    public interface FlowerBouquetRepository
    {
        List<FlowerBouquet> GetFlowerBouquets();
<<<<<<< HEAD
        FlowerBouquet FindFlowerBouquetById(int id);
=======
        //Task<List<FlowerBouquet>> GetFlowerBouquetsWithCategoryAndSupplier();
        List<FlowerBouquet> GetFlowerBouquetsWithCategoryAndSupplier();
        FlowerBouquet FindFlowerBouquetById(int id);
        FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplier(int id);
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        List<FlowerBouquet> FindFlowerBouquetContainName(string name);
        void SaveFlowerBouquet(FlowerBouquet flowerBouquet);
        void UpdateFlowerBouquet(FlowerBouquet flowerBouquet);
        void DeleteFlowerBouquet(FlowerBouquet flowerBouquet);
<<<<<<< HEAD
        FlowerBouquet GetFlowerBouquetWithTheLargestId();
=======
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
    }
}
