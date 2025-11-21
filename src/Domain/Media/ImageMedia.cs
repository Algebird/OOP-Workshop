using System;

namespace OOP_Workshop.Domain.Media
{
    public class ImageMedia : Media
    {
        public string Resolution { get; }
        public string FileFormat { get; }
        public string DateTaken { get; }

        public ImageMedia(string title, string genre, int year,
                          string resolution, string fileFormat, string dateTaken)
            : base("Image", title, genre, year, "N/A")
        {
            Resolution = resolution;
            FileFormat = fileFormat;
            DateTaken = dateTaken;
        }

        public override string GetDetails()
        {
            return
$@"--- Image Details ---
Title: {Title}
Genre: {Genre}
Year: {Year}
Resolution: {Resolution}
Format: {FileFormat}
Date Taken: {DateTaken}
Rating: {AverageRating:F1}/5
";
        }
    }
}
