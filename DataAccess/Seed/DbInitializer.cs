using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(CrayonCloudSalesContext context)
        {
            //context.Database.Migrate();
            context.Database.EnsureCreated();
            if (context.Customers!.Any())
            {
                return;   // DB already 
            }

            // Seed customers with associated accounts and software
            var customer1 = new Customer { Name = "Customer 1" };
            var customer2 = new Customer { Name = "Customer 2" };

            var account1 = new Account { Name = "ACC001", Customer = customer1 };
            var account2 = new Account { Name = "ACC002", Customer = customer2 };

            var software1 = new Software { Name = "Microsoft Office", Quantity = 1, State= "active", ValidTo = DateTime.UtcNow.AddMonths(1), Account = account1 };
            var software2 = new Software { Name = "Adobe Photoshop", Quantity = 1, State = "active", ValidTo = DateTime.UtcNow.AddMonths(1), Account = account2 };


            account1!.Softwares = new List<Software>() { software1 };
            account2!.Softwares = new List<Software>() { software2 };

            customer1!.Accounts = new List<Account>() { account1 };
            customer2!.Accounts = new List<Account>() { account2 };

            context.Customers!.AddRange(customer1, customer2);

            context.SaveChanges();
        }
    }

}
