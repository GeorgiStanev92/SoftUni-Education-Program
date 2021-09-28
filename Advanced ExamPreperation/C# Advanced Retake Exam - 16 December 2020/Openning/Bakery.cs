using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            var employeeToRemove = data.FirstOrDefault(e =>
            e.Name == name);

            if (employeeToRemove != null)
            {
                data.Remove(employeeToRemove);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            var oldestEmployee = data.OrderByDescending(e => e.Age)
                .FirstOrDefault();
            return oldestEmployee;
        }
        public Employee GetEmployee(string name)
        {
            var employee = data.FirstOrDefault(e =>
            e.Name == name);

            return employee;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var name in data)
            {
                sb.AppendLine(name.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
