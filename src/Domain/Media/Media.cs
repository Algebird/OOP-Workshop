namespace OOP_Workshop.Domain.Media
{
    public abstract class Media
    {
        public string Type { get; protected set; }
        public string Title { get; protected set; }
        public string Genre { get; protected set; }
        public int Year { get; protected set; }
        public string Language { get; protected set; }

        protected Media(string type, string title, string genre, int year, string language)
        {
            Type = type;
            Title = title;
            Genre = genre;
            Year = year;
            Language = language;
        }

        public override string ToString()
        {
            return $"{Type}: {Title} ({Year}) - {Genre}";
        }
    }
}
