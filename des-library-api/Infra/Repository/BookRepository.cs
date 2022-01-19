using System.Collections.Generic;
using System.Linq;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class BookRepository
    {
        private readonly IDictionary<int, Book> _books;

        public BookRepository(List<Book> books)
        {
            _books = books.ToDictionary(book => book.Id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values;
        }
        
        public Book Get(int id)
        {
            _books.TryGetValue(id, out var value);
            return value;
        }
    }
}
