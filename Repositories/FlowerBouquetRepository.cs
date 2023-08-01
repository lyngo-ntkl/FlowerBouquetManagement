using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
