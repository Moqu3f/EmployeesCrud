using EmployeesCrud.DAL.Repositories;
using EmployeesCrud.Models.Models;

namespace EmployeesCrud.BLL.Services;

public class EmployeeService:IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Employee GetEmployeeById(long id)
    {
        return _employeeRepository.GetById(id);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employeeRepository.GetAll();
    }

    public void AddEmployee(Employee employee)
    {
        _employeeRepository.Add(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        _employeeRepository.Update(employee);
    }

    public void DeleteEmployee(long id)
    {
        _employeeRepository.Delete(id);
    }

    public void SeedTestData()
    {
        var testData = new List<Employee>
        {
            new Employee { Name = "Іван Петров", Position = "Розробник", Age = 30, Salary = 50000 },
            new Employee { Name = "Марія Сидорова", Position = "Дизайнер", Age = 28, Salary = 45000 },
            new Employee { Name = "Михайло Іваненко", Position = "Менеджер", Age = 35, Salary = 60000 },
            new Employee { Name = "Олена Лисенко", Position = "Розробник", Age = 26, Salary = 48000 },
            new Employee { Name = "Василь Бровко", Position = "QA інженер", Age = 31, Salary = 52000 },
            new Employee { Name = "Ольга Дмитрієва", Position = "Дизайнер", Age = 29, Salary = 46000 },
            new Employee { Name = "Іван Мельник", Position = "Розробник", Age = 33, Salary = 55000 },
            new Employee { Name = "Софія Коваль", Position = "QA інженер", Age = 27, Salary = 49000 },
            new Employee { Name = "Олександр Ткач", Position = "Менеджер", Age = 38, Salary = 62000 },
            new Employee { Name = "Ізабелла Гарріс", Position = "Розробник", Age = 32, Salary = 53000 }
        };


        _employeeRepository.AddRange(testData);
    }

}