using System.Collections.Generic;
using des_library_api.Domain;
using des_library_api.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace des_library_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController()
        {
            var bs = new[]
            {
                new Book { Id = 1, Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Language = "English", Pages = 464 },
                new Book { Id = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", Language = "English", Pages = 240},
                new Book { Id = 1, Name = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma; Richard Helm; Ralph Johnson; John Vlissides", Language = "English", Pages = 416},
                new Book { Id = 1, Name = "Angular in Action", Author = "Jeremy Wilken", Language = "English", Pages = 320}
            };
            _bookRepository = new BookRepository(bs);
        }

        [HttpPost]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll();
        }
    }
}
