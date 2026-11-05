using Hw_5_Web.Models;
using Hw_5_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hw_5_Web.Controllers
{
    public class HomeController : Controller
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" },
            new Author { Id = 2, Name = "George R.R. Martin", Country = "USA" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter", Price = 29.99m, AuthorId = 1 },
            new Book { Id = 2, Title = "Game of Thrones", Price = 34.50m, AuthorId = 2 },
            new Book { Id = 3, Title = "The Philosopher's Stone", Price = 19.99m, AuthorId = 1 }
        };

        
        public IActionResult Index()
        {
            var model = new HomeViewModel();            
            foreach (var book in _books)
            {
                var author = _authors.FirstOrDefault(a => a.Id == book.AuthorId);
                model.Books.Add(new BookCardViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    AuthorName = author != null ? author.Name : "Unknown"
                });
            }

            model.Authors = _authors;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBook(string title, decimal price, int authorId)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                int newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(new Book
                {
                    Id = newId,
                    Title = title,
                    Price = price,
                    AuthorId = authorId
                });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            int newId = _authors.Any() ? _authors.Max(a => a.Id) + 1 : 1;
            _authors.Add(new Author
            {
                Id = newId,
                Name = name,
                Country = country
            });
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return RedirectToAction("Index");
        }

       
        public IActionResult About()
        {
            return View();
        }

       
        public IActionResult Contact()
        {
            return View();
        }
    }
}
