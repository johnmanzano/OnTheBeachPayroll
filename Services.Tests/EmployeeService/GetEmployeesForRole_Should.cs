using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Moq;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace Services.Tests
{
    [TestFixture]
    public class GetEmployeesForRole_Should
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
           // _unitOfWork.Setup(w => w.Employee.GetAll()).Returns(GetEmployeeList());

        }

        [Test]
        public void Return_List_Of_Employees_With_Assigned_Role()
        {
        
            //Assign
            int roleId = 1;

            //Act

            //Assert
        }

        [Test]
        public void Return_Empty_List_With_Unassigned_Role()
        {

        }
    }
}
