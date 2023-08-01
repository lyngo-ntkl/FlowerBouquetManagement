using BusinessObjects.Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories.Implement
{
    public class SupplierRepositoryImpl : SupplierRepository
    {
        public void Delete(Supplier supplier) => SupplierDAO.Delete(supplier);

        public Supplier Get(int id) => SupplierDAO.Get(id);

        public List<Supplier> GetAll() => SupplierDAO.GetAll();

        public void Save(Supplier supplier) => SupplierDAO.Save(supplier);

        public void Update(Supplier supplier) => SupplierDAO.Update(supplier);
    }
}
