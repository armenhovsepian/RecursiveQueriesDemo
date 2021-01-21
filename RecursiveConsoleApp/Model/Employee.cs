using System;
using System.Collections.Generic;

namespace RecursiveConsoleApp.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int? ManagerId { get; set; }
        public string FullName { get; set; }

        public static Employee FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Employee employee = new Employee();
            employee.EmployeeId = Convert.ToInt32(values[0]);
            employee.FullName = Convert.ToString(values[1]);
            employee.ManagerId = string.IsNullOrEmpty(values[2]) ? (int?)null : Convert.ToInt32(values[2]);

            return employee;
        }



        public IEnumerable<Employee> Children { get; set; } = new List<Employee>();



    }
}
