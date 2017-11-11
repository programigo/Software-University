namespace _05.ShopHierarchy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new MyDbContext())
            {
                PrepareDatabase(db);
                SaveSalesmen(db);
                SaveItems(db);
                ProcessCommands(db);
                //PrintSalesmanWithCustomerCount(db);
                //PrintCustomersWithOrdersAndReviewsCount(db);
                //PrintCustomerOrdersAndReviews(db);
                //PrintCustomerData(db);
                PrintOrdersWithMoreThanOneItem(db);
            }
        }

        private static void PrintOrdersWithMoreThanOneItem(MyDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var orders = db
                .Orders
                .Where(c => c.Id == customerId)
                .Count(c => c.Items.Count > 1);

            Console.WriteLine($"Orders: {orders}");
        }

        private static void PrintCustomerData(MyDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {customerData.Name}");
            Console.WriteLine($"Orders count: {customerData.Orders}");
            Console.WriteLine($"Reviews count: {customerData.Reviews}");
            Console.WriteLine($"Salesman: {customerData.Salesman}");
        }

        private static void PrintCustomerOrdersAndReviews(MyDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Select(o => new
                    {
                        o.Id,
                        Items = o.Items.Count
                    })
                        .OrderBy(o => o.Id),
                    Reviews = c.Reviews.Count
                }).FirstOrDefault();

            foreach (var order in customerData.Orders)
            {
                Console.WriteLine($"order {order.Id}: {order.Items} items");
            }

            Console.WriteLine($"reviews: {customerData.Reviews}");
        }

        private static void SaveItems(MyDbContext db)
        {
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                var parts = line.Split(';');

                var itemName = parts[0];

                var itemPrice = decimal.Parse(parts[1]);

                db.Add(new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                });
            }

            db.SaveChanges();
        }

        private static void PrintCustomersWithOrdersAndReviewsCount(MyDbContext db)
        {
            var customers = db
                .Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenByDescending(c => c.Reviews)
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name}");
                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");
            }
        }

        private static void PrintSalesmanWithCustomerCount(MyDbContext db)
        {
            var salesmanData = db
                .Salesmen
                .Select(s => new
                {
                    s.Name,
                    Customers = s.Customers.Count
                })
                .OrderByDescending(s => s.Customers)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var salesman in salesmanData)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.Customers} customers");
            }
        }

        private static void ProcessCommands(MyDbContext db)
        {
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                var parts = line.Split('-');
                var command = parts[0];
                var arguments = parts[1];

                switch (command)
                {
                    case "register":
                        RegisterCustomer(db, arguments);
                        break;

                    case "order":
                        SaveOrder(db, arguments);
                        break;

                    case "review":
                        SaveReview(db, arguments);
                        break;

                    default:
                        break;
                }
            }
        }

        private static void SaveReview(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');

            var customerId = int.Parse(parts[0]);

            var itemId = int.Parse(parts[1]);

            db.Add(new Review()
            {
                CustomerId = customerId,
                ItemId = itemId
            });

            db.SaveChanges();
        }

        private static void SaveOrder(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');

            var customerId = int.Parse(parts[0]);

            var order = new Order() { CustomerId = customerId };

            for (int i = 1; i < parts.Length; i++)
            {
                var itemId = int.Parse(parts[i]);

                order.Items.Add(new ItemOrder()
                {
                    ItemId = itemId
                });
            }

            db.Add(order);

            db.SaveChanges();
        }

        private static void RegisterCustomer(MyDbContext db, string arguments)
        {
            var parts = arguments.Split(';');

            var customerName = parts[0];

            var salesmanId = int.Parse(parts[1]);

            db.Add(new Customer()
            {
                Name = customerName,
                SalesmenId = salesmanId
            });

            db.SaveChanges();
        }

        private static void SaveSalesmen(MyDbContext db)
        {
            var salesmen = Console.ReadLine().Split(';');

            foreach (var salesman in salesmen)
            {
                db.Salesmen.Add(new Salesman() { Name = salesman });
            }

            db.SaveChanges();
        }

        private static void PrepareDatabase(MyDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}