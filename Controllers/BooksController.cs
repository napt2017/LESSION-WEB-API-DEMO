using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [ResponseType(typeof(List<Book>))]
        public List<Book> Get()
        {
            return _bookRepository.Get();
        }

        [ResponseType(typeof(Book))]
        public Book Get(string id)
        {
            return _bookRepository.Get(id);
        }

        [ResponseType(typeof(Book))]
        public Book PostBook(Book book)
        {
            return _bookRepository.Create(book);
        }

        public void Put(string id, Book book)
        {
            var existBook = _bookRepository.Get(id);
            if (existBook != null)
            {
                book.Id = existBook.Id;
                _bookRepository.Update(id,book);
            }
            else
            {
                throw new ArgumentException("Book not found");
            } 
        }

        public void Delete(string id)
        {
            var existBook = _bookRepository.Get(id);
            if (existBook != null)
            {
                _bookRepository.Remove(id);
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }
    }
}
