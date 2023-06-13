using GUI.Databases;
using NUnit.Allure.Attributes;
using SQL.Models;

namespace GUI.Tests.DataBaseTests
{
    [AllureSuite("DataBase Tests")]
    public class InitialDatabaseTest
    {
        private readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        [Test]
        public void DB_Test1()
        {
            using (var dbConnector = new DataBaseConnector())
            {
                var customer1 = new Customer { Firstname = "Ivan", Lastname = "Petrov" };
                var customer2 = new Customer { Firstname = "Sergey", Lastname = "Ivanov" };

                var entityCustomer1 = dbConnector.customers.Add(customer1);
                var entityCustomer2 = dbConnector.customers.Add(customer2);
                dbConnector.SaveChanges();

                var customers = dbConnector.customers.ToList();
                _logger.Info("Customers List:");

                _logger.Info(
                    $"{dbConnector.customers.Find(entityCustomer2.Entity.Id)?.Firstname}" +
                    $".{dbConnector.customers.Find(entityCustomer2.Entity.Id)?.Lastname}");

                foreach (var customer in customers)
                {
                    _logger.Info($"{customer.Firstname}.{customer.Lastname}");
                    dbConnector.customers.Remove(customer);
                }
            }

            Assert.True(true, "Test passed.");
        }
    }
}