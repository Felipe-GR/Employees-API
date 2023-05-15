using Employees_API.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Employees_API.DataAccessLayer
{
    public class EmployeeDataAccessLayer
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://dummy.restapiexample.com/api/v1/";

        public EmployeeDataAccessLayer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}employees");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content .ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonString);

            var employeesObject = jsonObject["data"];
            var employees = employeesObject.ToObject<List<Employee>>();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}employee/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonString);

            var employeeObject = jsonObject["data"];
            var employee = employeeObject.ToObject<Employee>();

            return employee;
        }
    }
}
