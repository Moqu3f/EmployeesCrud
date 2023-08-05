using EmployeesCrud.Models.Models;

namespace EmployeesCrud.DAL.Repositories;

public interface IEmployeeRepository
{
    Employee GetById(long id);
    List<Employee> GetAll();
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(long id);
    void AddRange(List<Employee> testData);
}