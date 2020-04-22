using LESSION_WEB_API_DEMO.Models;
using MongoDB.Driver;
using System.Collections.Generic; 

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface IBookRepository
    {
        List<Book> Get();
        Book Get(string id);
        Book Create(Book book);
        void Update(string id, Book book);
        void Remove(Book removeBook);
        void Remove(string id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(BookStoreDatabaseSettings bookStoreDatabaseSettings)
        {
            var client = new MongoClient(bookStoreDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(bookStoreDatabaseSettings.DataBaseName);
            _books = database.GetCollection<Book>(bookStoreDatabaseSettings.BookCollectionName);
        }

        public Book Create(Book book)
        { 
            _books.InsertOne(book);
            return book; 
        }

        public List<Book> Get()
        {
            return _books.Find(b => true).ToList();
        }

        public Book Get(string id)
        {
            return _books.Find(b => b.Id == id).FirstOrDefault();
        }

        public void Remove(Book removeBook)
        {
            _books.DeleteOne(b => b.Id == removeBook.Id);
        }

        public void Remove(string id)
        {
            _books.DeleteOne(b => b.Id == id);
        }

        public void Update(string id, Book book)
        {
            _books.ReplaceOne(b => b.Id == id, book);
        }
    }
}