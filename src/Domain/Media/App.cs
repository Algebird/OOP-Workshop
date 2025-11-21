using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class App : Media, IUsable, IDownloadable
    {
        public string Publisher { get; }
        public string Platform { get; }
        public string Version { get; }
        public double FileSize { get; }

        public App(string title, string genre, int year, string publisher,
                   string platform, string version, double fileSize)
            : base("App", title, genre, year, "N/A")
        {
            Publisher = publisher;
            Platform = platform;
            Version = version;
            FileSize = fileSize;
        }

        public void Open() => Console.WriteLine($"Opening app '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading app '{Title}'...");

        public override string GetDetails()
        {
            return
$@"--- App Details ---
Title: {Title}
Genre: {Genre}
Year: {Year}
Publisher: {Publisher}
Platform: {Platform}
Version: {Version}
Size: {FileSize} MB
Rating: {AverageRating:F1}/5
";
        }
    }
}
