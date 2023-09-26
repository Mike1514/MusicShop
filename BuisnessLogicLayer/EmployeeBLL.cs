using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BuisnessLogicLayer;
using DataAccessLayer;
using AutoMapper;
using BuisnessLogicLayer.Models;
using DataAccessLayer.Repository.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessLogicLayer
{
    public class EmployeeBLL
    {
        private DataAccessLayer.EmployeeDAL _EmployeeDAL;
        private Mapper _EmployeeMapper;

        public EmployeeBLL()
        {
            _EmployeeDAL = new DataAccessLayer.EmployeeDAL();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
            });

            _EmployeeMapper = new Mapper(configuration);
        }

        public Employee EditEmployee([FromBody] EmployeeDTO employe)
        {
            var Employee =
                _EmployeeMapper.Map<Employee>(employe);
            _EmployeeDAL.EditEmployee(Employee);
            return Employee;
        }

        public Employee AddEmployee(EmployeeDTO a)
        {
            var Employee = 
                _EmployeeMapper.Map<Employee>(a); 
             _EmployeeDAL.AddEmployee(Employee);
            return Employee;


        }

        public List<EmployeeModel> GetAllEmployeInfo()
        {
            List<Employee> EmployeeFromDB = _EmployeeDAL.GetAllEmployeInfo();
            List<EmployeeModel> EmployeeModel =
                _EmployeeMapper.Map<List<Employee>, List<EmployeeModel>>(EmployeeFromDB);
            return EmployeeModel;
        }

        public EmployeeModel GetEmploeeById(int Id)
        {
            var EmployeeEntity = _EmployeeDAL.GetEmployeeById(Id);

            if (EmployeeEntity == null)
            {
                throw new Exception("Invalid Id");
            }

            EmployeeModel EmployeeModel =
                _EmployeeMapper.Map<Employee, EmployeeModel>(EmployeeEntity);
            return EmployeeModel;
        }

        public Employee DeleteEmployee(int Id)
        {
            return _EmployeeDAL.DeleteEmployeeById(Id);
        }
    }
}
