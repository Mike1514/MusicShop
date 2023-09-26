using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer
{
    public class EmployeeDAL
    {
        public Employee AddEmployee([FromBody] Employee a)
        {
            var db = new DotNetLabDbContext();
            db.Add(a);
            db.SaveChanges();
            return a;

        }
        public Employee EditEmployee([FromBody] Employee employee)
        {
            var db = new DotNetLabDbContext();
            Employee a = new Employee();
            a = db.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (a != null)
            {
                a.FirstName = employee.FirstName;
                a.LastName = employee.LastName;
                a.MiddleName = employee.MiddleName;               
                a.DateOfBirth = employee.DateOfBirth;
                a.Position = employee.Position;
                a.StoreId = employee.StoreId;
            }
            db.SaveChangesAsync();
            return employee;
        }
        public Employee GetEmployeeById(int Id)
        {
            var db = new DotNetLabDbContext();
            Employee a = new Employee();
            a = db.Employees.FirstOrDefault(x => x.Id == Id);
            return a;
        }

        public List<Employee> GetAllEmployeInfo()
        {
            var db = new DotNetLabDbContext();
            return db.Employees.ToList();
        }
        public Employee DeleteEmployeeById(int Id)
        {
            var db = new DotNetLabDbContext();
            Employee a = db.Employees.FirstOrDefault(x => x.Id == Id);

            if (Id != null)
            {
                db.Employees.Remove(a);
            }
            db.SaveChanges();
            return a;
        }

    }
}
