using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class ImageMedia : Media, IDownloadable, IUsable, IRatable
    {
        public string Resolution { get; }
        public string FileFormat { get; }
        public string DateTaken { get; }

        public ImageMedia(string title, string genre, int year,
                          string resolution, string format, string date)
            : base("Image", title, genre, year, "")
        {
            Resolution = resolution;
            FileFormat = format;
            DateTaken = date;
        }

        public void Download() => Console.WriteLine($"Downloading image '{Title}'...");
        public void Open() => Console.WriteLine($"Opening image '{Title}'...");
        public void Rate(int stars) => Console.WriteLine($"Rated image '{Title}' {stars} stars.");
    }
}
