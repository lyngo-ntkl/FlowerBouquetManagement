using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

namespace Repositories.Implement
{
    public class FlowerBouquetRepositoryImpl : FlowerBouquetRepository
    {
        public void DeleteFlowerBouquet(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.DeleteFlowerBouquet(flowerBouquet);

        public FlowerBouquet FindFlowerBouquetById(int id) => FlowerBouquetDAO.FindFlowerBouquetsById(id);
<<<<<<< HEAD
=======
        public FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplier(int id) => FlowerBouquetDAO.FindFlowerBouquetsById(id);
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

        public List<FlowerBouquet> FindFlowerBouquetContainName(string name) => FlowerBouquetDAO.FindFlowerBouquetContainName(name);

        public List<FlowerBouquet> GetFlowerBouquets() => FlowerBouquetDAO.GetFlowerBouquets();
<<<<<<< HEAD

        public FlowerBouquet GetFlowerBouquetWithTheLargestId() => FlowerBouquetDAO.GetFlowerBouquetWithTheLargestId();

        public void SaveFlowerBouquet(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.SaveFlowerBouquet(flowerBouquet);
=======
        //public Task<List<FlowerBouquet>> GetFlowerBouquetsWithCategoryAndSupplier() => FlowerBouquetDAO.GetFlowerBouquetsWithCategoryAndSupplier();
        public List<FlowerBouquet> GetFlowerBouquetsWithCategoryAndSupplier() => FlowerBouquetDAO.GetFlowerBouquetsWithCategoryAndSupplier();

        public void SaveFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            if(flowerBouquet.FlowerBouquetId == 0)
            {
                flowerBouquet.FlowerBouquetId = FlowerBouquetDAO.GetFlowerBouquetWithTheLargestId().FlowerBouquetId + 1;
            }
            FlowerBouquetDAO.SaveFlowerBouquet(flowerBouquet);
        }
>>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

        public void UpdateFlowerBouquet(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.UpdateFlowerBouquet(flowerBouquet);
    }
}
