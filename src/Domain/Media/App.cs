using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class App : Media, IDownloadable, IUsable, IRatable
    {
        public string Publisher { get; }
        public string Platform { get; }
        public string Version { get; }
        public double FileSize { get; }

        public App(string title, string genre, int year, string publisher,
                   string platform, string version, double size)
            : base("App", title, genre, year, "")
        {
            Publisher = publisher;
            Platform = platform;
            Version = version;
            FileSize = size;
        }

        public void Download() => Console.WriteLine($"Downloading app '{Title}'...");
        public void Open() => Console.WriteLine($"Opening app '{Title}'...");
        public void Rate(int stars) => Console.WriteLine($"Rated app '{Title}' {stars} stars.");
    }
}
