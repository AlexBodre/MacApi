using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MacApi.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MacApi.Services
{
    public class EmployeeService : IEmployeeData
    {
        private readonly DataContext _context;
        public EmployeeService(DataContext context)
        {
            _context = context;
        }


        public Employee AddEmployee(Employee newEmployee)
        {
            var nuevo = _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return nuevo.Entity;
        }


        public Employee GetEmployee(int codigo)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Codigo == codigo);
            return employee;
        }


        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }

        public Employee ModifyEmployee(Employee updateEmployee)
        {
            _context.Entry(updateEmployee).State = EntityState.Modified;
            _context.SaveChanges();
            return updateEmployee;

        }

        public void DeleteEmployee(int codigo)
        {
            try
            {
                var registrado = _context.Employees.Find(codigo);
                if (registrado != null)
                {
                    _context.Remove(registrado);
                    _context.SaveChanges();
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
