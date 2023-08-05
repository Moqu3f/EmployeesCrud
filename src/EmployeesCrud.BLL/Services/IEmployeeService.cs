using EmployeesCrud.Models.Models;

namespace EmployeesCrud.BLL.Services;

public interface IEmployeeService
{
    Employee GetEmployeeById(long id);
    List<Employee> GetAllEmployees();
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(long id);
    
    void SeedTestData();
}