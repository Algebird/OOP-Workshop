using System;
using MediaType = OOP_Workshop.Domain.Media.Media;

namespace OOP_Workshop.Domain.User
{
    public class Employee : User
    {
        public Employee(string name, string ssn, int age)
            : base(name, ssn, age) { }

        public void AddToLibrary(Library library, MediaType media)
        {
            library.Add(media);
        }

        public bool RemoveFromLibrary(Library library, MediaType media)
        {
            return library.Remove(media);
        }

        public override void RateMedia(MediaType media, int rating)
        {
            media.AddRating(rating);
            Console.WriteLine($"{Name} rated '{media.Title}' with {rating} stars. Average rating: {media.AverageRating:F2}");
        }
    }
}
