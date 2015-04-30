using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using Data.Repositories;
using Moq;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace Services.Tests
{

    // ReSharper disable once InconsistentNaming
    [TestFixture]
    public class GetEmployeeSalary_Should
    {

        private EmployeeService _employeeService;
        private Mock<IUnitOfWorkFactory> _unitOfWorkFactory;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            _unitOfWorkFactory = new Mock<IUnitOfWorkFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _employeeService = new EmployeeService(_unitOfWorkFactory.Object);

            _unitOfWorkFactory.Setup(f => f.Create()).Returns(_unitOfWork.Object);
            _unitOfWork.Setup(w => w.Employee.GetAll()).Returns(GetEmployeeList());

        }

        [Test]
        public void Return_Salary_For_Valid_Employee()
        {
            //Assign
            string employeeName = "Valid Employee";

            //Act
            var employeeSalary = _employeeService.GetEmployeeSalary(employeeName);

            //Assert
            Assert.AreEqual(7879.22, employeeSalary.GbpSalary);
        }


        [Test]
        public void Return_Null_For_Invalid_Employee()
        {
            //Assign
            var employee = "Invalid Employee";

            //Act
            var employeeSalary = _employeeService.GetEmployeeSalary(employee);

            //Assert
            Assert.AreEqual(null, employeeSalary);
        }


        private IQueryable<Employee> GetEmployeeList()
        {
            var employee = new List<Employee>
            {
                new Employee
                {
                    Name = "Valid Employee",
                    Salaries = new Collection<Salary>
                    {
                        new Salary
                        {
                            AnnualAmount = 12134,
                            Currency = new Currency
                            {
                                Unit = "USD",
                                ConversionFactor = (decimal) 1.54
                            }
                        }
                    }
                },
                new Employee
                {
                    Name = "Another Employee One"
                },
                new Employee
                {
                    Name = "Another Employee Two"
                }
            };

            return employee.AsQueryable();
        }


    }
}
