using System;
using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class EBook : Media, IDownloadable, IUsable
    {
        public string Author { get; }
        public string ISBN { get; }
        public int Pages { get; }

        public EBook(string title, string author, string genre, int year, string language, string isbn, int pages)
            : base("EBook", title, genre, year, language)
        {
            Author = author;
            ISBN = isbn;
            Pages = pages;
        }

        public void Download() => Console.WriteLine($"Downloading eBook '{Title}'...");
        public void Open() => Console.WriteLine($"Opening eBook '{Title}'...");

        public override string GetDetails()
        {
            return
$@"--- EBook Details ---
Title: {Title}
Author: {Author}
Genre: {Genre}
Year: {Year}
Language: {Language}
ISBN: {ISBN}
Pages: {Pages}
Rating: {AverageRating:F1}/5
";
        }
    }
}
