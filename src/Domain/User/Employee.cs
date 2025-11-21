using OOP_Workshop.Domain;

namespace OOP_Workshop.Domain.User
{
    public class Employee : User
    {
        public Employee(string name, string ssn, int age) : base(name, ssn, age) { }


        public void AddToLibrary(Library library, Media.Media media)
        {
            library.Add(media);
        }

        public void RemoveFromLibrary(Library library, Media.Media media)
        {
            library.GetAllMedia().ToList().Remove(media);
        }
    }
}
