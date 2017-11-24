namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Suppliers;
    using Services;

    public class SuppliersController : Controller
    {
        private const string SuppliersView = "Suppliers";

        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult All()
        {
            return View(this.suppliers.AllModifies());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SupplierFormModel model)
        {
            this.suppliers.Create(
                model.Name,
                model.IsImporter);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            return View(id);
        }

        public IActionResult Destroy(int id)
        {
            this.suppliers.Delete(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var supplier = this.suppliers.ById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(new SupplierFormModel
            {
                Name = supplier.Name,
                IsImporter = supplier.IsImporter,
                IsEdit = true
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, SupplierFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsEdit = true;
                return View(model);
            }

            this.suppliers.Edit(
                id,
                model.IsImporter);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Local()
        {
            return View(SuppliersView, this.GetSupplierModel(false));
        }

        public IActionResult Importers()
        {
            return View(SuppliersView, this.GetSupplierModel(true));
        }

        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";

            var suppliers = this.suppliers.AllListings(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}
