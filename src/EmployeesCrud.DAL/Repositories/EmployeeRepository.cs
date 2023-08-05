using EmployeesCrud.DAL.Context;
using EmployeesCrud.DAL.Repositories;
using EmployeesCrud.Models.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _dbContext;

    public EmployeeRepository(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Employee GetById(long id)
    {
        return _dbContext.Employees.Find(id);
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Employees.ToList();
    }

    public void Add(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
    }

    public void Update(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(long id)
    {
        var employee = _dbContext.Employees.Find(id);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }

    public void AddRange(List<Employee> testData)
    {
        _dbContext.Employees.AddRange(testData);
        _dbContext.SaveChanges();
    }
}