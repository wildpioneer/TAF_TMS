using Npgsql;
using SQL.Models;

namespace GUI.DAO;

public class CustomerDao : ICustomerDao
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public CustomerDao(NpgsqlConnection connection)
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

    public Customer GetById(int id)
    {
        using (var command = new NpgsqlCommand("SELECT * FROM customers WHERE id = @id", _connection))
        {
            command.Parameters.AddWithValue("id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Customer()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                        Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Age = reader.GetInt32(reader.GetOrdinal("age"))
                    };
                }
            }
        }

        return null;
    }

    public int Add(Customer customer)
    {
        using (var command = new NpgsqlCommand("INSERT INTO customers (firstname, lastname, email, age) " +
                                               "VALUES (@firstname, @lastname, @email, @age)",
                   _connection))
        {
            command.Parameters.AddWithValue("firstname", customer.Firstname);
            command.Parameters.AddWithValue("lastname", customer.Lastname);
            command.Parameters.AddWithValue("email", customer.Email);
            command.Parameters.AddWithValue("age", customer.Age);
            
            return command.ExecuteNonQuery();
        }
    }

    public int Update(Customer customer)
    {
        using (var command = new NpgsqlCommand("UPDATE customers SET firstname = @firstname, lastname = @lastname, " +
                                               "email = @email, age = @age WHERE id = @id",
                   _connection))
        {
            command.Parameters.AddWithValue("firstname", customer.Firstname);
            command.Parameters.AddWithValue("lastname", customer.Lastname);
            command.Parameters.AddWithValue("email", customer.Email);
            command.Parameters.AddWithValue("age", customer.Age);
            command.Parameters.AddWithValue("id", customer.Id);
            
            return command.ExecuteNonQuery();
        }
    }

    public int Delete(int? id)
    {
        using (var command = new NpgsqlCommand("DELETE FROM customers WHERE id = @id",
                   _connection))
        {
            command.Parameters.AddWithValue("id", id);
            
            return command.ExecuteNonQuery();
        }
    }
}