namespace OOP_Workshop.Domain.User
{
    public class Admin : Employee
    {
        public Admin(string name, string ssn, int age) : base(name, ssn, age) { }


        public void DeleteUser(User user)
        {
            Console.WriteLine($"Admin {Name} deleted user {user.Name}");
        }
    }
}
