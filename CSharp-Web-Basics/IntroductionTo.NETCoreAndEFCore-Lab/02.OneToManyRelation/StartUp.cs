namespace _02.OneToManyRelation
{
    public class Startup
    {
        public static void Main()
        {
            var db = new MyDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department() { Name = "Foreign Languages" };

            department.Employees.Add(new Employee() { Name = "Stefan" });

            db.Departments.Add(department);

            db.SaveChanges();
        }
    }
}