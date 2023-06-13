using System.Diagnostics;
using GUI.DAO;
using GUI.Databases;
using GUI.Services;
using NUnit.Framework.Constraints;
using SQL.Models;

namespace GUI.Tests.DataBaseTests;

public class DaoDatabaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private CustomerDao? _customerDao;
    private SimpleDBConnector? _simpleDbConnector;
        
    [OneTimeSetUp]
    public void SetUpConnection()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customerDao = new CustomerDao(_simpleDbConnector.Connection);
    }

    [OneTimeTearDown]
    public void closeConnection()
    {
        _simpleDbConnector?.CloseConnection();
    }
    
    [Test]
    public void GetAllCustomersTest()
    {
        _logger.Info("GetAllCustomersTest started...");
        var customersList = _customerDao?.GetAllCustomers();

        Assert.That(customersList, Has.Count.GreaterThan(2));

        _logger.Info("GetAllCustomersTest completed...");
    }

    [Test]
    public void AddCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        
        Assert.AreEqual(1, _customerDao?.Add(new Customer
        {
            Firstname = "Alexandr",
            Lastname = "Trostyanko",
            Email = "test@test.com",
            Age = 43
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }

    [Test]
    public void DeleteCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        Assert.AreEqual(1, _customerDao?.Delete(_customerDao?.GetAllCustomers()[0].Id));
        
        _logger.Info("AddCustomerTest completed...");
    }
}