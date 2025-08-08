using System;

/*
    A generalized reporting system that accpets any enumerable data structers and takes an action on the filtered items.

*/

Action<string> wl = (message) => Console.WriteLine(message);
Action nl = () => Console.WriteLine();

List<Employee> employees = new List<Employee>();
int id = 1;
employees.Add(new Employee { Id = id++, Name = "Daryl", Department = "Engineering", Salary = 1247});
employees.Add(new Employee { Id = id++, Name = "Rick", Department = "Engineering", Salary = 1427});
employees.Add(new Employee { Id = id++, Name = "Negan", Department = "Engineering", Salary = 2147});
employees.Add(new Employee { Id = id++, Name = "Maggie", Department = "MacrodataRefinement", Salary = 4217});
employees.Add(new Employee { Id = id++, Name = "Glen", Department = "MacrodataRefinement", Salary = 4127});

ReportingService reportingService = new ReportingService();

wl("Engineers:");
reportingService.ProcessAndReport<Employee>(employees, x => x.Department == "Engineering", x => wl(x.Name));
nl();

wl("High earners:");
reportingService.ProcessAndReport<Employee>(employees, x => x.Salary > 2000, x => wl($"Employee with id {x.Id} earns {x.Salary}."));
nl();

wl("Monthly report:");
reportingService.ProcessAndReport<Employee>(employees, x => true, x => wl($"[id: {x.Id}], [Department: {x.Department}], [Salary: {x.Salary}]"));

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public double Salary { get; set; }
}

public class ReportingService
{
    public void ProcessAndReport<T>(IEnumerable<T> items, Func<T, bool> filter, Action<T> reportAction)
    {
        foreach (T item in items)
        {
            if (filter(item))
            {
                reportAction(item);
            }
        }
    }
}