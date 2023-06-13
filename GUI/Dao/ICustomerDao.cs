using SQL.Models;

namespace GUI.DAO;

public interface ICustomerDao
{
    List<Customer> GetAllCustomers();
    Customer GetById(int id);
    int Add(Customer customer);
    int Update(Customer customer);
    int Delete(int? id);
    void Create();
    void Drop();
}