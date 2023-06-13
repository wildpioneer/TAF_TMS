using GUI.Databases;
using GUI.Services;
using SQL.Models;

namespace GUI.Tests.DataBaseTests;

public class SimpleDatabaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private CustomerService? _customerService;
    private SimpleDBConnector? _simpleDbConnector;
        
    [OneTimeSetUp]
    public void SetUpConnection()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customerService = new CustomerService(_simpleDbConnector.Connection);
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
        var customersList = _customerService?.GetAllCustomers();

        Assert.AreEqual(2, customersList.Count);

        _logger.Info("GetAllCustomersTest completed...");
    }

    [Test]
    public void AddCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        Assert.AreEqual(1, _customerService?.AddCustomer(new Customer
        {
            Firstname = "Alexandr",
            Lastname = "Trostyanko"
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }

    [Test]
    public void DeleteCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        Assert.AreEqual(1, _customerService?.DeleteCustomer(new Customer
        {
            Firstname = "Alexandr",
            Lastname = "Trostyanko"
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }
}