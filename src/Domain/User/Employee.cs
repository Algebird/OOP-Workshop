using OOP_Workshop.Domain.Media;

namespace OOP_Workshop.Domain.User
{
    public class Employee : User
    {
        public Employee(string name, string ssn, int age)
            : base(name, ssn, age) { }

        public void AddToLibrary(Library library, Media media)
        {
            library.Add(media);
        }

        public bool RemoveFromLibrary(Library library, Media media)
        {
            return library.Remove(media);
        }
    }
}
