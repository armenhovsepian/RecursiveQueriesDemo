using RecursiveConsoleApp.Extensions;
using RecursiveConsoleApp.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecursiveConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();

            var hierachy1 = employees.RecursiveJoin(element => element.EmployeeId,
                element => element.ManagerId ?? 0,
                (Employee element, int index, int depth, IEnumerable<TreeViewItemModel> children) =>
                {
                    return new TreeViewItemModel
                    {
                        Id = element.EmployeeId,
                        Text = element.FullName,
                        Items = children.ToList(),
                        depth = depth
                    };
                }).ToList();



            var hierachy2 = employees.AsHierarchy(e => e.ManagerId, e => e.ManagerId).ToList();
        }

        private static List<Employee> GetEmployees()
        {
            return File.ReadAllLines("Data\\employees.csv")
                               .Skip(1)
                               .Select(v => Employee.FromCsv(v))
                               .ToList();
        }
    }
}
