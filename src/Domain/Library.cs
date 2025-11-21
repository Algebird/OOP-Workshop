using OOP_Workshop.Domain.Media;

namespace OOP_Workshop.Domain
{
    public class Library
    {
        private List<Media> _items = new();

        public void Add(Media m) => _items.Add(m);

        public bool Remove(Media m) => _items.Remove(m);

        public IEnumerable<Media> GetAllMedia() => _items;
    }
}
