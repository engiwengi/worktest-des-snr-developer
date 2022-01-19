using System;
using System.Collections.Generic;
using System.Linq;
using des_library_api.Controllers;
using des_library_api.Domain;
using des_library_api.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace des_library_api_test.Controllers
{
    [TestFixture]
    public class BookControllerTest
    {
        private BookController _controller;

        [SetUp]
        public void Init()
        {
            _controller = new BookController(new BookRepository(), new UserRepository());
        }

        [Test]
        public void CreateShouldCreateNewUser()
        {
            var newUser = _controller.CreateUser();

            Assert.IsNotNull(newUser);
        }

        [Test]
        public void BorrowShouldSucceed()
        {
            var books = _controller.Get();
            var newUser = _controller.CreateUser();

            var unborrowedBook = books.First(b => b.BorrowedBy == Guid.Empty);

            var result = _controller.BorrowBook(unborrowedBook.Id, newUser);

            Assert.That(result is OkResult);

            var newlyBorrowed = _controller.Get(unborrowedBook.Id);

            Assert.That(newlyBorrowed.BorrowedBy, Is.EqualTo(newUser.Id));
        }

        [Test]
        public void BorrowBorrowedBookShouldFail()
        {
            var books = _controller.Get();
            var newUser = _controller.CreateUser();

            var unborrowedBook = books.First(b => b.BorrowedBy != Guid.Empty);

            var result = _controller.BorrowBook(unborrowedBook.Id, newUser);

            Assert.That(result is ForbidResult);
        }

        [Test]
        public void ReturnUnborrowedBookShouldFail()
        {
            var books = _controller.Get();
            var newUser = _controller.CreateUser();

            var unborrowedBook = books.First(b => b.BorrowedBy == Guid.Empty);

            var result = _controller.ReturnBook(unborrowedBook.Id, newUser);

            Assert.That(result is ForbidResult);
        }

    }
}
