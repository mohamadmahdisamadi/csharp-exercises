using System;
using System.Linq;

/*
    This query groups employees by their department and projects department names alongside with their average salary,
    at the end it sorts the result based on that average and displays a report of each department.
*/

List<Employee> employees = new List<Employee>();
int id = 1;
employees.Add(new Employee { Id = id++, Name = "Daryl", Department = "OpticsAndDesign", Salary = 10});
employees.Add(new Employee { Id = id++, Name = "Rick", Department = "OpticsAndDesign", Salary = 9});
employees.Add(new Employee { Id = id++, Name = "Negan", Department = "OpticsAndDesign", Salary = 8});
employees.Add(new Employee { Id = id++, Name = "Maggie", Department = "MacrodataRefinement", Salary = 6});
employees.Add(new Employee { Id = id++, Name = "Carol", Department = "MacrodataRefinement", Salary = 7});
employees.Add(new Employee { Id = id++, Name = "Carl", Department = "MacrodataRefinement", Salary = 3});
employees.Add(new Employee { Id = id++, Name = "Rosita", Department = "MacrodataRefinement", Salary = 4});
employees.Add(new Employee { Id = id++, Name = "Shane", Department = "WellnessCenter", Salary = 5});
employees.Add(new Employee { Id = id++, Name = "Judith", Department = "WellnessCenter", Salary = 1});
employees.Add(new Employee { Id = id++, Name = "Eugene", Department = "WellnessCenter", Salary = 2});

var report = employees
        .Where(e => true)
        .GroupBy(e => e.Department)
        .Select(g => new { DepartmentName = g.Key, AvgSalary = g.Average(e => e.Salary), Count = g.Count()})
        .OrderByDescending(g => g.AvgSalary)
        .ToList();

var res = from p in employees
            where p.IsNigga()
            select new Employee { Id = p.Id + 10, Name = p.Name + ".", Department = p.Department + "." , Salary = p.Salary * 2 };

foreach (var item in res)
{
    Console.WriteLine($"{item.Department}, {item.Name}, {item.Salary}");
}

public class Employee
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public double Salary { get; init; }
    public bool IsNigga() { return Id > 5; }
}