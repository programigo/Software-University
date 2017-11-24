namespace CarDealer.Services
{
    using Data.Models;
    using Models;
    using Models.Customers;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Ordered(OrderDirection order);

        CustomerTotalSalesModel TotalSalesById(int id);

        void Create(string name, DateTime birthday, bool isYoungDiver);

        void Edit(int id, string modelName, DateTime modelBirthday, bool modelIsYoungDriver);

        CustomerModel ById(int id);

        bool Exists(int id);

        IEnumerable<CustomerBasicModel> All();
    }
}
