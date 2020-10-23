namespace Lab7
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}