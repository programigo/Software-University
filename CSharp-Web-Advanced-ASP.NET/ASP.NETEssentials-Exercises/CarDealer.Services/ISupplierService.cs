using CarDealer.Services.Models.Suppliers;

namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> AllListings(bool isImporter);

        IEnumerable<SupplierModel> All();

        IEnumerable<SupplierModifyingModel> AllModifies();

        SupplierEditingModel ById(int id);

        void Create(string name, bool isImporter);

        void Delete(int id);

        void Edit(int id, bool isImporter);
    }
}
