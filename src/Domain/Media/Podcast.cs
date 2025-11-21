using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Podcast : Media, IPlayable, IDownloadable, IUsable, IRatable
    {
        public string Host { get; }
        public string Guest { get; }
        public int Episode { get; }

        public Podcast(string title, string genre, int year,
                       string lang, string host, string guest, int episode)
            : base("Podcast", title, genre, year, lang)
        {
            Host = host;
            Guest = guest;
            Episode = episode;
        }

        public void Play() => Console.WriteLine($"Playing podcast '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading podcast '{Title}'...");
        public void Open() => Play();
        public void Rate(int stars) => Console.WriteLine($"Rated podcast '{Title}' {stars} stars.");
    }
}
