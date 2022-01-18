using System.Collections.Generic;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class BookRepository
    {
        private readonly IEnumerable<Book> _books;

        public BookRepository(List<Book> books)
        {
            _books = books;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }
    }
}
