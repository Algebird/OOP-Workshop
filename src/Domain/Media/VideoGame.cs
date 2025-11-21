using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class VideoGame : Media, IUsable
    {
        public string Publisher { get; }
        public string Platform { get; }

        public VideoGame(string title, string genre, int year, string publisher, string platform)
            : base("VideoGame", title, genre, year, "N/A")
        {
            Publisher = publisher;
            Platform = platform;
        }

        public void Open() => Console.WriteLine($"Launching video game '{Title}'...");

        public override string GetDetails()
        {
            return
$@"--- Video Game Details ---
Title: {Title}
Genre: {Genre}
Year: {Year}
Publisher: {Publisher}
Platform: {Platform}
Rating: {AverageRating:F1}/5
";
        }
    }
}
