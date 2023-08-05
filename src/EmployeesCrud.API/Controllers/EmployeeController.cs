using EmployeesCrud.API.ViewModels;
using EmployeesCrud.BLL.Services;
using EmployeesCrud.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCrud.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("seed")]
    public IActionResult SeedTestData()
    {
        _employeeService.SeedTestData();
        return Ok("Test data seeded successfully.");
    }

    [HttpGet("all")]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        var employeeViewModels = EmployeeMapper.MapToViewModels(employees);
        return Ok(employeeViewModels);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(long id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }

        var employeeViewModel = EmployeeMapper.MapToViewModel(employee);
        return Ok(employeeViewModel);
    }

    [HttpPost("add")]
    public IActionResult AddEmployee(EmployeeViewModel employeeViewModel)
    {
        if (employeeViewModel == null)
        {
            return BadRequest();
        }

        var employee = EmployeeMapper.MapToModel(employeeViewModel);
        _employeeService.AddEmployee(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employeeViewModel);
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateEmployee(long id, EmployeeViewModel employeeViewModel)
    {
        if (employeeViewModel == null || id != employeeViewModel.Id)
        {
            return BadRequest();
        }

        var existingEmployee = _employeeService.GetEmployeeById(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }

        var updatedEmployee = EmployeeMapper.MapToModel(employeeViewModel);
        _employeeService.UpdateEmployee(updatedEmployee);
        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteEmployee(long id)
    {
        var existingEmployee = _employeeService.GetEmployeeById(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }

        _employeeService.DeleteEmployee(id);
        return NoContent();
    }
}
