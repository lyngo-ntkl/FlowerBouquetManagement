using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface SupplierRepository
    {
        List<Supplier> GetSuppliers();
        Supplier FindSupplierById(int id);
        void SaveSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
