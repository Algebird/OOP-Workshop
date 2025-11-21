using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Song : Media, IPlayable, IDownloadable, IUsable
    {
        public string Singer { get; }
        public string Composer { get; }
        public int Duration { get; }

        public Song(string title, string singer, string composer,
                    string genre, int year, string language, int duration)
            : base("Song", title, genre, year, language)
        {
            Singer = singer;
            Composer = composer;
            Duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing song '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading song '{Title}'...");
        public void Open() => Play();

        public override string GetDetails()
        {
            return
$@"--- Song Details ---
Title: {Title}
Singer: {Singer}
Composer: {Composer}
Genre: {Genre}
Year: {Year}
Language: {Language}
Duration: {Duration} sec
Rating: {AverageRating:F1}/5
";
        }
    }
}
