namespace EmployeesCrud.Models.Models;

public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
}