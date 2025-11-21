using MediaType = OOP_Workshop.Domain.Media.Media;

namespace OOP_Workshop.Domain.User
{
    public abstract class User
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public int Age { get; set; }

        protected User(string name, string ssn, int age)
        {
            Name = name;
            SSN = ssn;
            Age = age;
        }

        public abstract void RateMedia(MediaType media, int rating);
    }
}
