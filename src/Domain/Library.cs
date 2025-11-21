using System.Collections.Generic;
using MediaType = OOP_Workshop.Domain.Media.Media;

namespace OOP_Workshop.Domain
{
    public class Library
    {
        private List<MediaType> _items = new();

        public void Add(MediaType m) => _items.Add(m);
        public bool Remove(MediaType m) => _items.Remove(m);
        public IEnumerable<MediaType> GetAllMedia() => _items;

        public MediaType SearchByTitle(string title)
        {
            return _items.Find(m => m.Title.ToLower() == title.ToLower());
        }
    }
}
