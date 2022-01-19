using System.Collections.Generic;
using System.Linq;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class BookRepository
    {
        private readonly IDictionary<int, Book> _books;

        public BookRepository()
        {
            var bs = new List<Book>()
            {
                new Book { Id = 1, Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Language = "English", Pages = 464 },
                new Book { Id = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", Language = "English", Pages = 240},
                new Book { Id = 3, Name = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma; Richard Helm; Ralph Johnson; John Vlissides", Language = "English", Pages = 416, BorrowedBy = UserRepository.ExampleUser},
                new Book { Id = 4, Name = "Angular in Action", Author = "Jeremy Wilken", Language = "English", Pages = 320}
            };
            _books = bs.ToDictionary(book => book.Id);
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
