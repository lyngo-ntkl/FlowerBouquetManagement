using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Implement
{
    public class FlowerBouquetRepositoryImpl : FlowerBouquetRepository
    {
        public void DeleteFlowerBouquet(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.DeleteFlowerBouquet(flowerBouquet);

        public FlowerBouquet FindFlowerBouquetById(int id) => FlowerBouquetDAO.FindFlowerBouquetsById(id);
        public FlowerBouquet FindFlowerBouquetsByIdWithCategoryAndSupplier(int id) => FlowerBouquetDAO.FindFlowerBouquetsById(id);

        public List<FlowerBouquet> FindFlowerBouquetContainName(string name) => FlowerBouquetDAO.FindFlowerBouquetContainName(name);

        public List<FlowerBouquet> GetFlowerBouquets() => FlowerBouquetDAO.GetFlowerBouquets();
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

        public void UpdateFlowerBouquet(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.UpdateFlowerBouquet(flowerBouquet);
    }
}
