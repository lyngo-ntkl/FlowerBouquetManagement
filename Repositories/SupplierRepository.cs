using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface SupplierRepository
    {
        List<Supplier> GetAll();
        Supplier Get(int id);
        void Save(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
    }
}
