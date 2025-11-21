using OOP_Workshop.Domain.Media;

namespace OOP_Workshop.Domain.User
{
    public class Admin : Employee
    {
        public Admin(string name, string ssn, int age)
            : base(name, ssn, age) { }

        public void CreateUser(List<User> users, User newUser)
        {
            users.Add(newUser);
        }

        public bool DeleteUser(List<User> users, User user)
        {
            return users.Remove(user);
        }

        public void UpdateUser(User user, string newName, string newSSN, int newAge)
        {
            user.Name = newName;
            user.SSN = newSSN;
            user.Age = newAge;
        }
    }
}
