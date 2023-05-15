using Employees_API.DataAccessLayer;
using Employees_API.Model;

namespace Employees_API.BusinessLogicLayer
{
    public class EmployeeBusinessLogicLayer
    {
        private readonly EmployeeDataAccessLayer _dataAccessLayer;

        public EmployeeBusinessLogicLayer()
        {
        }

        public EmployeeBusinessLogicLayer(EmployeeDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public decimal CalculateEmployeeAnnualWage(Employee employee)
        {
            return employee.employee_salary * 12;
        }
    }
}
