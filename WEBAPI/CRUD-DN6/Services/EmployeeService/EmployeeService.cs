using CRUD_DN6.DataContext;
using CRUD_DN6.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD_DN6.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponseModel<List<EmployeeModel>>> createEmployee(EmployeeModel newEmployee)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                if (newEmployee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Informe os dados.";
                    serviceResponse.success = false;

                    return serviceResponse;
                }
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.data = _context.employees2.ToList();
            }catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<EmployeeModel>>> deleteEmployeeById(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                EmployeeModel employee = _context.employees2.FirstOrDefault(x => x.id == id);
                if (employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não encontrado.";
                    serviceResponse.success = false;
                }
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                serviceResponse.data = _context.employees2.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<EmployeeModel>>> disableEmployee(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                EmployeeModel employee = _context.employees2.FirstOrDefault(x => x.id == id);
                if (employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não encontrado.";
                    serviceResponse.success = false;
                    return serviceResponse;
                }
                if (employee.active == false)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário já está desabilitado.";
                    serviceResponse.success = false;
                    return serviceResponse;
                }
                employee.active = false;
                employee.updatedAt = DateTime.Now.ToLocalTime();
                _context.employees2.Update(employee);
                serviceResponse.data = _context.employees2.ToList();
                serviceResponse.message = "Usuário desabilitado com sucesso.";
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<EmployeeModel>>> enableEmployee(int id)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                EmployeeModel employee = _context.employees2.FirstOrDefault(x => x.id == id);
                if (employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não encontrado.";
                    serviceResponse.success = false;
                    return serviceResponse;
                }
                if (employee.active == true)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário já está habilitado.";
                    serviceResponse.success = false;
                    return serviceResponse;
                }
                employee.active = true;
                employee.updatedAt = DateTime.Now.ToLocalTime();
                serviceResponse.message = "Usuário habilitado com sucesso.";
                serviceResponse.data = _context.employees2.ToList();
                _context.employees2.Update(employee);
                await _context.SaveChangesAsync();

            }catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<EmployeeModel>> getEmployeeById(int id)
        {
            ServiceResponseModel<EmployeeModel> serviceResponse = new ServiceResponseModel<EmployeeModel>();
            try
            {
                EmployeeModel employee = _context.employees2.FirstOrDefault(x => x.id == id);
                if(employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não localizado.";
                    serviceResponse.success = false;
                }
                serviceResponse.data = employee;
            }catch(Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }
        
        public async Task<ServiceResponseModel<List<EmployeeModel>>> getEmployees()
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                serviceResponse.data = _context.employees2.ToList();
                if (serviceResponse.data.Count == 0)
                {
                    serviceResponse.message = "Nenhum dado encontrado!";
                }
            }catch(Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<EmployeeModel>>> updateEmployee(EmployeeModel editEmployee)
        {
            ServiceResponseModel<List<EmployeeModel>> serviceResponse = new ServiceResponseModel<List<EmployeeModel>>();
            try
            {
                EmployeeModel employee = _context.employees2.AsNoTracking().FirstOrDefault(x => x.id == editEmployee.id);
                if (employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não encontrado.";
                    serviceResponse.success = false;
                }
                employee.updatedAt = DateTime.Now.ToLocalTime();
                _context.employees2.Update(editEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.data = _context.employees2.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
            }
            return serviceResponse;
        }
    }
}
