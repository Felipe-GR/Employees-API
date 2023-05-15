using Employees_API.BusinessLogicLayer;
using Employees_API.Model;
using NUnit.Framework;

namespace Employees_Test
{
    [TestFixture]
    public class BusinessLayerTests
    {
        [Test]
        public void CalculateEmployeeAnnualWage_ShouldCalculateCorrectly()
        {
            var employee = new Employee
            {
                id = 1,
                employee_name = "Tiger Nixon",
                employee_salary = 320800,
                employee_age = 61,
                profile_image = ""
            };

            var expectedAnnualWage = employee.employee_salary * 12;

            EmployeeBusinessLogicLayer employeeBusinessLogicLayer = new EmployeeBusinessLogicLayer();
            var calculatedAnnualWage = employeeBusinessLogicLayer.CalculateEmployeeAnnualWage(employee);

            Assert.AreEqual(expectedAnnualWage, calculatedAnnualWage);
        }
    }
}
