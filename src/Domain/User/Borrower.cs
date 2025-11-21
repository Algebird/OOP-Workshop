using System;
using MediaType = OOP_Workshop.Domain.Media.Media;

namespace OOP_Workshop.Domain.User
{
    public class Borrower : User
    {
        public Borrower(string name, string ssn, int age)
            : base(name, ssn, age) { }

        public override void RateMedia(MediaType media, int rating)
        {
            media.AddRating(rating);
            Console.WriteLine($"{Name} rated '{media.Title}' with {rating} stars. Average rating: {media.AverageRating:F2}");
        }
    }
}
