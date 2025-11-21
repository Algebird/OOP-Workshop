using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Podcast : Media, IPlayable
    {
        public string Host { get; }
        public string Guest { get; }
        public int Episode { get; }

        public Podcast(string title, string genre, int year, string language,
                       string host, string guest, int episode)
            : base("Podcast", title, genre, year, language)
        {
            Host = host;
            Guest = guest;
            Episode = episode;
        }

        public void Play() => Console.WriteLine($"Playing podcast '{Title}'...");

        public override string GetDetails()
        {
            return
$@"--- Podcast Details ---
Title: {Title}
Host: {Host}
Guest: {Guest}
Episode: {Episode}
Genre: {Genre}
Year: {Year}
Language: {Language}
Rating: {AverageRating:F1}/5
";
        }
    }
}
