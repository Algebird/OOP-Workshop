using OOP_Workshop.Domain;
using OOP_Workshop.Domain.Media;

namespace OOP_Workshop.Persistence
{
    public class CsvLoader
    {
        private readonly string _path;

        public CsvLoader(string path)
        {
            _path = path;
        }

        public Library LoadLibrary()
        {
            Library library = new Library();

            var lines = File.ReadAllLines(_path).Skip(1);

            foreach (var line in lines)
            {
                var c = line.Split(',');

                string type = c[0];

                switch (type)
                {
                    case "EBook":
                        library.Add(new EBook(
                            c[1], c[2], c[4], int.Parse(c[5]), c[6], c[7], int.Parse(c[8])
                        ));
                        break;

                    case "Movie":
                        library.Add(new Movie(
                            c[1], c[3], c[4], int.Parse(c[5]), c[7], int.Parse(c[9])
                        ));
                        break;

                    case "Song":
                        library.Add(new Song(
                            c[1], c[10], c[11], c[4], int.Parse(c[5]), c[7], int.Parse(c[9])
                        ));
                        break;

                    case "VideoGame":
                        library.Add(new VideoGame(
                            c[1], c[4], int.Parse(c[5]), c[13], c[14]
                        ));
                        break;

                    case "App":
                        library.Add(new App(
                            c[1], c[4], int.Parse(c[5]), c[13], c[14], c[15], double.Parse(c[16])
                        ));
                        break;

                    case "Podcast":
                        library.Add(new Podcast(
                            c[1], c[4], int.Parse(c[5]), c[7], c[21], c[22], int.Parse(c[23])
                        ));
                        break;

                    case "Image":
                        library.Add(new ImageMedia(
                            c[1], c[4], int.Parse(c[5]), c[17], c[18], c[19]
                        ));
                        break;
                }
            }

            return library;
        }
    }
}
