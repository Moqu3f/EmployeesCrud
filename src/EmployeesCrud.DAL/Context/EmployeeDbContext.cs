using EmployeesCrud.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCrud.DAL.Context;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
    
    

}