using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class SupplierRepositoryImpl : SupplierRepository
    {
        public void DeleteSupplier(Supplier supplier) => SupplierDAO.DeleteSupplier(supplier);

        public Supplier FindSupplierById(int id) => SupplierDAO.FindSupplierById(id);

        public List<Supplier> GetSuppliers() => SupplierDAO.GetSuppliers();

        public void SaveSupplier(Supplier supplier) => SupplierDAO.SaveSupplier(supplier);

        public void UpdateSupplier(Supplier supplier) => SupplierDAO.UpdateSupplier(supplier);
    }
}
