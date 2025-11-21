using OOP_Workshop.Domain.Interfaces;

namespace OOP_Workshop.Domain.Media
{
    public class EBook : Media, IDownloadable, IUsable, IRatable
    {
        public string Author { get; }
        public string ISBN { get; }
        public int Pages { get; }

        public EBook(string title, string author, string genre, int year,
                     string isbn, string lang, int pages)
            : base("EBook", title, genre, year, lang)
        {
            Author = author;
            ISBN = isbn;
            Pages = pages;
        }

        public void Download() => Console.WriteLine($"Downloading ebook '{Title}'...");
        public void Open() => Console.WriteLine($"Opening ebook '{Title}'...");
        public void Rate(int stars) => Console.WriteLine($"Rated ebook '{Title}' {stars} stars.");
    }
}
