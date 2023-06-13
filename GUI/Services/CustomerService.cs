using Npgsql;
using SQL.Models;

namespace GUI.Services;

public class CustomerService
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public CustomerService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<Customer> GetAllCustomers()
    {
        var customersList = new List<Customer>();
        
        // Retrieve all rows
        using var cmd = new NpgsqlCommand("SELECT * FROM \"customers\";", _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var customer = new Customer
            {
                Id = reader.GetInt32(0),
                Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                Lastname = reader.GetString(reader.GetOrdinal("lastname"))
            };
            
            _logger.Info(customer.ToString);
            
            customersList.Add(customer);
        }
        
        return customersList;
    }

    public int AddCustomer(Customer customer)
    {
        using var cmd = new NpgsqlCommand("INSERT INTO \"customers\" (firstname, lastname) VALUES ($1, $2);", _connection)
        {
            Parameters =
            {
                new() {Value = customer.Firstname},
                new() {Value = customer.Lastname}
            }
        };

        return cmd.ExecuteNonQuery();
    }

    public int DeleteCustomer(Customer customer)
    {
        using var cmd = new NpgsqlCommand("DELETE FROM \"customers\" WHERE firstname = $1 AND lastname = $2;", _connection)
        {
            Parameters =
            {
                new() {Value = customer.Firstname},
                new() {Value = customer.Lastname}
            }
        };

        return cmd.ExecuteNonQuery();
    }
}