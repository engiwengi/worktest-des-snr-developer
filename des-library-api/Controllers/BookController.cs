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

        public BookController(BookRepository bookRepository, UserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
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

        [HttpPut("borrow/{bookId}")]
        public IActionResult BorrowBook([FromRoute] int bookId, [FromBody] User requestUser)
        {
            var book = _bookRepository.Get(bookId);
            var user = _userRepository.Get(requestUser.Id);

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


        [HttpPut("return/{bookId}")]
        public IActionResult ReturnBook([FromRoute] int bookId, [FromBody] User requestUser)
        {
            var book = _bookRepository.Get(bookId);
            var user = _userRepository.Get(requestUser.Id);

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
