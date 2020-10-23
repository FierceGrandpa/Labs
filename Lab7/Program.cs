using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        public class WorkContext : DbContext
        {
            public WorkContext() : base("DbConnection") { }

            public DbSet<Employee> Workers { get; set; }
            public DbSet<Department> Departments { get; set; }
        }

        static void Main()
        {
            using var db = new WorkContext();

            db.Database.Delete();

            var dep1 = new Department { Name = "Department1" };
            var dep2 = new Department { Name = "Department2" };
            var dep3 = new Department { Name = "Department3" };

            db.Departments.Add(dep1);
            db.Departments.Add(dep2);
            db.Departments.Add(dep3);

            db.SaveChanges();

            var worker1 = new Employee { Surname = "Surname1", Department = dep1 };
            var worker2 = new Employee { Surname = "Surname2", Department = dep1 };
            var worker3 = new Employee { Surname = "Surname3", Department = dep2 };
            var worker4 = new Employee { Surname = "аSurname4", Department = dep2 };
            var worker5 = new Employee { Surname = "АSurname5", Department = dep3 };

            db.Workers.AddRange(new List<Employee> { worker1, worker2, worker3, worker4, worker5 });

            db.SaveChanges();

            foreach (var worker in db.Workers.Include(p => p.Department))
            {
                Console.WriteLine($"{worker.Surname} - {(worker.DepartmentId != null ? worker.Department.Name : "")}");
            }
            Console.WriteLine();

            foreach (var dep in db.Departments.Include(dep => dep.State))
            {
                Console.WriteLine($"Department: {dep.Name}");
                foreach (var worker in dep.State)
                {
                    Console.WriteLine($"{worker.Surname}");
                }
                Console.WriteLine();
            }

            // Tasks

            var union = db.Workers.Join
            (
                db.Departments,
                worker     => worker.Id, 
                department => department.Id,
                (worker, department) => new
                {
                    depID         = department.Id,
                    depName       = department.Name,
                    workerID      = worker.Id, 
                    WorkerSurname = worker.Surname
                }
            );

            // Выведите список всех сотрудников и отделов, отсортированный по отделам.
            Console.WriteLine("\nID) Department Name | ID) Surname");
            foreach (var tuple in union.OrderBy(x => x.depName))
            {
                Console.WriteLine($"{tuple.depID}) {tuple.depName} | " +
                                  $"{tuple.workerID}) {tuple.WorkerSurname}");
            }

            // Выведите список всех сотрудников, у которых фамилия начинается с буквы «А».
            Console.WriteLine("\nID) Surname");
            foreach (var worker in db.Workers.Where(w => w.Surname.ToUpper().StartsWith("А")))
            {
                Console.WriteLine($"{worker.Id}) {worker.Surname}");
            }

            // Выведите список всех отделов и количество сотрудников в каждом отделе.
            Console.WriteLine();
            foreach (var dep in db.Departments.Include(dep => dep.State))
            {
                Console.WriteLine($"Department: {dep.Name} -> {dep.State.Count} worker.");
            }

            // Выведите список отделов, в которых у всех сотрудников фамилия начинается с буквы «А».
            Console.WriteLine("\nID) Department Name");
            foreach (var dep in db.Departments.Include(dep => dep.State)
                .Where(x => x.State.All(y => y.Surname.ToUpper().StartsWith("А"))))
            {
                Console.WriteLine($"{dep.Id}) {dep.Name}");
            }

            // Выведите список отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы «А».
            Console.WriteLine("\nID) Department Name");
            foreach (var dep in db.Departments.Include(dep => dep.State)
                .Where(x => x.State.Any(y => y.Surname.ToUpper().StartsWith("А"))))
            {
                Console.WriteLine($"{dep.Id}) {dep.Name}");
            }


            Console.ReadLine();
        }
    }
}
