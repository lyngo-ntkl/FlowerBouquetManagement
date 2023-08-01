using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface FlowerBouquetRepository
    {
        List<FlowerBouquet> GetAll();
        FlowerBouquet Get(int id);
        void Save(FlowerBouquet flowerBouquet);
        void Update(FlowerBouquet flowerBouquet);
        void Delete(FlowerBouquet flowerBouquet);
    }
}
