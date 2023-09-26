using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repository.DTO;

namespace WebAPI.Controllers
{
  
        [ApiController]
        [Route("[controller]")]
        public class EmployeeController : ControllerBase
        {
            private BuisnessLogicLayer.EmployeeBLL _employeeBll;

            public EmployeeController()
            {
                _employeeBll = new BuisnessLogicLayer.EmployeeBLL();
            }

            [HttpGet]
            [Route("GetAllEmployeesInfo")]

            public List<EmployeeModel> GetAllEmployeInfo()
            {
                return _employeeBll.GetAllEmployeInfo();
            }


            [HttpPost]
            [Route("AddEmployee")]
            public Employee AddEmployee([FromBody] EmployeeDTO a)
            {
                return _employeeBll.AddEmployee(a);
            }

            [HttpGet]
            [Route("GetEmployeeById")]
            public EmployeeModel GetMediaById(int Id)
            {
                return _employeeBll.GetEmploeeById(Id);
            }


            [HttpPut]
            [Route("EditEmployeeById")]
            public Employee EditEmployee([FromBody] EmployeeDTO employe)
            {
                return _employeeBll.EditEmployee(employe);
            }


            [HttpDelete]
            [Route("DeleteEmployeeById")]
            public Employee DeleteEmployeeById(int Id)
            {
                return _employeeBll.DeleteEmployee(Id);
            }

        }
    }

