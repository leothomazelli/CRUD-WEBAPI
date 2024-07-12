using CRUD_DN6.Models;

namespace CRUD_DN6.Services.EmployeeService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponseModel<List<EmployeeModel>>> getEmployees();
        Task<ServiceResponseModel<List<EmployeeModel>>> createEmployee(EmployeeModel newEmployee);
        Task<ServiceResponseModel<EmployeeModel>> getEmployeeById(int id);
        Task<ServiceResponseModel<List<EmployeeModel>>> updateEmployee(EmployeeModel editEmployee);
        Task<ServiceResponseModel<List<EmployeeModel>>> deleteEmployeeById(int id);
        Task<ServiceResponseModel<List<EmployeeModel>>> disableEmployee(int id);
        Task<ServiceResponseModel<List<EmployeeModel>>> enableEmployee(int id);
    }
}
