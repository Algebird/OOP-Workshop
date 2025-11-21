namespace OOP_Workshop.Domain.Media
{
    public abstract class Media
    {
        public string Type { get; }
        public string Title { get; }
        public string Genre { get; }
        public int Year { get; }
        public string Language { get; }
        protected readonly List<int> Ratings = new();

        public double AverageRating =>
            Ratings.Count == 0 ? 0 : Ratings.Average();

        protected Media(string type, string title, string genre, int year, string language)
        {
            Type = type;
            Title = title;
            Genre = genre;
            Year = year;
            Language = language;
        }

        public void AddRating(int stars)
        {
            if (stars < 1 || stars > 5)
                throw new ArgumentException("Rating must be between 1 and 5");

            Ratings.Add(stars);
        }

        public abstract string GetDetails();
    }
}
