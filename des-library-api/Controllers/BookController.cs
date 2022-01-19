using System;
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
        private readonly UserRepository _userRepository;

        public BookController()
        {
            var exampleUser = new User() { Id = Guid.NewGuid() };

            var bs = new List<Book>()
            {
                new Book { Id = 1, Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Language = "English", Pages = 464 },
                new Book { Id = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", Language = "English", Pages = 240},
                new Book { Id = 3, Name = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma; Richard Helm; Ralph Johnson; John Vlissides", Language = "English", Pages = 416, BorrowedBy = exampleUser.Id},
                new Book { Id = 4, Name = "Angular in Action", Author = "Jeremy Wilken", Language = "English", Pages = 320}
            };


            _bookRepository = new BookRepository(bs);
            _userRepository = new UserRepository(new List<User>() { exampleUser });
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Book Get([FromRoute] int bookId)
        {
            return _bookRepository.Get(bookId);
        }


        [HttpPut("borrow/{id}")]
        public ActionResult BorrowBook([FromRoute] int bookId, [FromBody] Guid userId)
        {
            var book = _bookRepository.Get(bookId);
            var user = _userRepository.Get(userId);

            if (book is null || user is null)
            {
                return NotFound();
            }

            if (book.BorrowedBy != Guid.Empty && book.BorrowedBy != user.Id)
            {
                return Forbid();
            }

            book.BorrowedBy = user.Id;

            return Ok();
        }


        [HttpPut("return/{id}")]
        public ActionResult ReturnBook([FromRoute] int bookId, [FromBody] Guid userId)
        {
            var book = _bookRepository.Get(bookId);
            var user = _userRepository.Get(userId);

            if (book is null || user is null)
            {
                return NotFound();
            }

            if (book.BorrowedBy != user.Id)
            {
                return Forbid();
            }

            book.BorrowedBy = Guid.Empty;

            return Ok();
        }

        [HttpPost("create_user")]
        public User CreateUser()
        {
            return _userRepository.Create();
        }
    }
}
