namespace CarDealer.Services.Implementations
{
    using CarDealer.Data.Models;
    using Data;
    using Models.Suppliers;
    using System.Collections.Generic;
    using System.Linq;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierListingModel> AllListings(bool isImporter)
            => this.db
                .Suppliers
                .OrderByDescending(s => s.Id)
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count
                })
                .ToList();

        public IEnumerable<SupplierModel> All()
        {
            return this.db
                .Suppliers
                .OrderBy(s => s.Name)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();
        }

        public IEnumerable<SupplierModifyingModel> AllModifies()
        {
            return this.db
                .Suppliers
                .Select(s => new SupplierModifyingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();
        }

        public void Create(string name, bool isImporter)
        {
            var supplier = new Supplier
            {
                Name = name,
                IsImporter = isImporter
            };

            this.db.Add(supplier);

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = this.db.Suppliers.Find(id);

            if (supplier == null)
            {
                return;
            }

            this.db.Suppliers.Remove(supplier);

            this.db.SaveChanges();
        }

        public SupplierEditingModel ById(int id)
        {
            return this.db
                .Suppliers
                .Where(s => s.Id == id)
                .Select(s => new SupplierEditingModel
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .FirstOrDefault();
        }

        public void Edit(int id, bool isImporter)
        {
            var supplier = this.db.Suppliers.Find(id);

            if (supplier == null)
            {
                return;
            }

            supplier.IsImporter = isImporter;

            this.db.SaveChanges();
        }
    }
}
