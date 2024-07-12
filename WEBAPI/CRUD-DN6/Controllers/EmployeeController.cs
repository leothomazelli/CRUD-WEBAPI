using CRUD_DN6.Models;
using CRUD_DN6.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DN6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> getEmployees()
        {
            return Ok(await _employeeInterface.getEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponseModel<EmployeeModel>>> getEmployeeById(int id)
        {
            return Ok(await _employeeInterface.getEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> createEmployee(EmployeeModel newEmployee)
        {
            return Ok(await _employeeInterface.createEmployee(newEmployee));
        }

        [HttpPut("disableEmployee")]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> disableEmployee(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = await _employeeInterface.disableEmployee(id);
            return Ok(serviceResponse);
        }

        [HttpPut("enableEmployee")]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> enableEmployee(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = await _employeeInterface.enableEmployee(id);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> updateEmployee(EmployeeModel editEmployee)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = await _employeeInterface.updateEmployee(editEmployee);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponseModel<List<EmployeeModel>>>> deleteEmployee(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = await _employeeInterface.deleteEmployeeById(id);
            return Ok(serviceResponse);
        }
    }
}
