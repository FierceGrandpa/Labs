using System.Collections.Generic;

namespace Lab7
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public ICollection<Employee> State { get; set; }
        public Department()
        {
            State = new List<Employee>();
        }
    }
}