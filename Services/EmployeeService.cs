using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories;
using Services.Models;

namespace Services
{
    public interface IEmployeeService
    {
        EmployeeSalary GetEmployeeSalary(string employeeName);
    }

    public class EmployeeService : IEmployeeService
    {
        //private readonly IEmployeeRepository _employeeRepository;

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public EmployeeService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public EmployeeService(IUnitOfWorkFactory unitOfWorkFactory) 
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }


        /// <summary>
        /// Gets the employee salary.
        /// </summary>
        /// <param name="employeeName">Name of the employee.</param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeSalary(string employeeName)
        {

            using (var uow = _unitOfWorkFactory.Create())
            {
                var employee = uow.Employee.GetAll().FirstOrDefault(e => e.Name == employeeName);

                if (employee != null)
                {
                    string currencyUnit = "";
                    double gbpSalary = 0;
                    double localCurrencySalary = 0;

                    var salary = employee.Salaries.FirstOrDefault();
                    if (salary != null)
                    {
                        currencyUnit = salary.Currency.Unit;
                        gbpSalary = Math.Round((double)(salary.AnnualAmount / salary.Currency.ConversionFactor), 2);
                        localCurrencySalary = salary.AnnualAmount;
                    }

                    return EmployeeSalary(employee, currencyUnit, gbpSalary, localCurrencySalary);
                }
                return null;
            
            }   

        }


        /// <summary>
        /// Gets the employees by staff level.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeSalary> GetEmployeesByStaffLevel()
        {
           var uow = _unitOfWorkFactory.Create();
            

            var employees = uow.Employee.GetAll().Where(e => e.RoleId == 1).ToList();


            var employSalary = (from employee in employees
                select employee.Salaries.FirstOrDefault()
                into salary
                where salary != null
                select new EmployeeSalary()
                {
                    CurrencyUnit = salary.Currency.Unit, 
                    LocalCurrencySalary = salary.AnnualAmount, 
                    Name = salary.Employee.Name,
                    GbpSalary = Math.Round((double)(salary.AnnualAmount / salary.Currency.ConversionFactor), 2)

                }).ToList();
            
            
            return employSalary.OrderByDescending(s => s.LocalCurrencySalary).ToList(); 
        }


        /// <summary>
        /// Employees the salary.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="currencyUnit">The currency unit.</param>
        /// <param name="gbpSalary">The GBP salary.</param>
        /// <param name="localCurrencySalary">The local currency salary.</param>
        /// <returns></returns>
        private static EmployeeSalary EmployeeSalary(Employee employee, string currencyUnit, double gbpSalary,
            double localCurrencySalary)
        {
            return new EmployeeSalary
            {
                Id = employee.Id,
                Name = employee.Name,
                CurrencyUnit = currencyUnit,
                GbpSalary = gbpSalary,
                LocalCurrencySalary = localCurrencySalary
            };
        }

        
    }
}
