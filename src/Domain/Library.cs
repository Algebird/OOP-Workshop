using OOP_Workshop.Domain.Media;

namespace OOP_Workshop.Domain
{
    public class Library
    {
        private List<Media.Media> _items = new();

        public void Add(Media.Media m) => _items.Add(m);

        public IEnumerable<Media.Media> GetAllMedia() => _items;

        public Media.Media? SearchByTitle(string title)
        {
            return _items.FirstOrDefault(m =>
                m.Title.ToLower().Contains(title.ToLower()));
        }
    }
}
