using EmployeesCrud.Models.Models;

namespace EmployeesCrud.API.ViewModels;

public static class EmployeeMapper
{
    public static List<EmployeeViewModel> MapToViewModels(List<Employee> employees)
    {
        var employeeViewModels = new List<EmployeeViewModel>();
        foreach (var employee in employees)
        {
            employeeViewModels.Add(MapToViewModel(employee));
        }

        return employeeViewModels;
    }
    
    public static EmployeeViewModel MapToViewModel(Employee employee)
    {
        return new EmployeeViewModel
        {
            Id = employee.Id,
            Name = employee.Name,
            Position = employee.Position,
            Age = employee.Age,
            Salary = employee.Salary
        };
    }

    public static Employee MapToModel(EmployeeViewModel employeeViewModel)
    {
        return new Employee
        {
            Id = employeeViewModel.Id,
            Name = employeeViewModel.Name,
            Position = employeeViewModel.Position,
            Age = employeeViewModel.Age,
            Salary = employeeViewModel.Salary
        };
    }
}