using Employees_API.BusinessLogicLayer;
using Employees_API.DataAccessLayer;
using Employees_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employees_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDataAccessLayer _dataAccessLayer;
        private readonly EmployeeBusinessLogicLayer _businessLogicLayer;

        public EmployeeController(EmployeeDataAccessLayer dataAccessLayer, EmployeeBusinessLogicLayer businessLogicLayer)
        {
            _dataAccessLayer = dataAccessLayer;
            _businessLogicLayer = businessLogicLayer;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _dataAccessLayer.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _dataAccessLayer.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("{id}/annualWage")]
        public async Task<ActionResult<decimal>> GetEmployeeAnnualWage(int id)
        {
            var employee = await _dataAccessLayer.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var annualWage = _businessLogicLayer.CalculateEmployeeAnnualWage(employee);
            return Ok(annualWage);
        }
    }
}
