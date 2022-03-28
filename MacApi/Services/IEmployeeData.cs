using System;
using System.Collections.Generic;
using MacApi.Models;

namespace MacApi.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int codigo);
        Employee AddEmployee(Employee newEmployee);
        Employee ModifyEmployee(Employee updateEmployee);

        void DeleteEmployee(int codigo);
    }
}
