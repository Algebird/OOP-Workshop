using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class VideoGame : Media, IPlayable, IDownloadable, IUsable, IRatable
    {
        public string Publisher { get; }
        public string Platform { get; }

        public VideoGame(string title, string genre, int year, string publisher, string platform)
            : base("VideoGame", title, genre, year, "")
        {
            Publisher = publisher;
            Platform = platform;
        }

        public void Play() => Console.WriteLine($"Launching game '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading game '{Title}'...");
        public void Open() => Play();
        public void Rate(int stars) => Console.WriteLine($"Rated game '{Title}' {stars} stars.");
    }
}
