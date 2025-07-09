using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYFirstApi.Data;
using MYFirstApi.Models;
using MYFirstApi.Models.Dto;

namespace MYFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;
        public EmployeeController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var allEmployees = DbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee == null)
            {
                return BadRequest("This user Might not be there");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {

            if (employeeDto == null)
            {
                return BadRequest("Employee data is null or invalid.");
            }

            var EmployeeData = new Employee()
            {
                email = employeeDto.email,
                name = employeeDto.name,
                phone = employeeDto.phone,
                salary = employeeDto.salary
            };


            DbContext.Employees.Add(EmployeeData);
            DbContext.SaveChanges();

            return Ok(EmployeeData);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult UpdateEmployeeData(Guid id,UpdateEmployeeDto updateEmployee)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound("This employee does not exist");
            }

            employee.name = updateEmployee.name;
            employee.email = updateEmployee.email;
            employee.phone = updateEmployee.phone;
            employee.salary = updateEmployee.salary;

            DbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteEmployeeData(Guid id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound("This employee does not exist");
            }

            DbContext.Employees.Remove(employee);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
