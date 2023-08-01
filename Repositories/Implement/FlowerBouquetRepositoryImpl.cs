using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class FlowerBouquetRepositoryImpl : FlowerBouquetRepository
    {
        public void Delete(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.Delete(flowerBouquet);

        public FlowerBouquet Get(int id) => FlowerBouquetDAO.Get(id);

        public List<FlowerBouquet> GetAll() => FlowerBouquetDAO.GetAll();

        public void Save(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.Save(flowerBouquet);

        public void Update(FlowerBouquet flowerBouquet) => FlowerBouquetDAO.Update(flowerBouquet);
    }
}
