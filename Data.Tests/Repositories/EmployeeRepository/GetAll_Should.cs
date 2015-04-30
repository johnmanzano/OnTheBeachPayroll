using System.Linq;
using Data.Repositories;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace Data.Tests.Repositories
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class GetAll_Should
    {
        [Test]
        [Ignore]
        // not a continuous integration test, just used for intitial cod development
        public void Retrieve_Specific_Employee()
        {
            //Assign
            var repository = new EmployeeRepository(new EmployeeContext()); 

            //Act
            var result = repository.GetAll().Where(e => e.Name == "Fred Flintstone").ToList().FirstOrDefault();

            //Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(4, result.Id);
        }


        [Test]
        [Ignore]
        // not a continuous integration test, just used for intitial cod development
        public void Retrieve_List_Of_Employees()
        {
            //Assign
            var repository = new EmployeeRepository(new EmployeeContext());

            //Act
            var result = repository.GetAll().ToList();

            //Assert
            Assert.Greater(result.Count, 0);
        }
    }
}
