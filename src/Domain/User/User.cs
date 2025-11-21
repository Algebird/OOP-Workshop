namespace OOP_Workshop.Domain.User
{
    public abstract class User
    {
        public string Name { get; }
        public string SocialSecurityNumber { get; }
        public int Age { get; }

        protected User(string name, string ssn, int age)
        {
            Name = name;
            SocialSecurityNumber = ssn;
            Age = age;
        }

        public abstract void RateMedia(Media.Media media, int stars);
    }
}
