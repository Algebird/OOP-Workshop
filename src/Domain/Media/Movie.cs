using System;
using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class Movie : Media, IPlayable
    {
        public string Director { get; }
        public int Duration { get; }

        public Movie(string title, string director, string genre, int year, string language, int duration)
            : base("Movie", title, genre, year, language)
        {
            Director = director;
            Duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing movie '{Title}'...");

        public override string GetDetails()
        {
            return
$@"--- Movie Details ---
Title: {Title}
Director: {Director}
Genre: {Genre}
Year: {Year}
Language: {Language}
Duration: {Duration} minutes
Rating: {AverageRating:F1}/5
";
        }
    }
}
