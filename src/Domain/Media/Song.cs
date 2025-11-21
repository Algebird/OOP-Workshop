using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Song : Media, IPlayable, IDownloadable, IUsable, IRatable
    {
        public string Singer { get; }
        public string Composer { get; }
        public int Duration { get; }

        public Song(string title, string singer, string composer,
                    string genre, int year, string lang, int duration)
            : base("Song", title, genre, year, lang)
        {
            Singer = singer;
            Composer = composer;
            Duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing song '{Title}'...");
        public void Download() => Console.WriteLine($"Downloading song '{Title}'...");
        public void Open() => Play();
        public void Rate(int stars) => Console.WriteLine($"Rated song '{Title}' {stars} stars.");
    }
}
