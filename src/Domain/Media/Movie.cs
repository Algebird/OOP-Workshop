using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Movie : Media, IPlayable, IDownloadable, IUsable, IRatable
    {
        public string Director { get; }
        public int Duration { get; }

        public Movie(string title, string director, string genre, int year,
                     string lang, int duration)
            : base("Movie", title, genre, year, lang)
        {
            Director = director;
            Duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing movie '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading movie '{Title}'...");
        public void Open() => Play();
        public void Rate(int stars) => Console.WriteLine($"Rated movie '{Title}' {stars} stars.");
    }
}
