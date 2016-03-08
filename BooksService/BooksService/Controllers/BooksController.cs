using BooksService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksService.Controllers
{
    [AllowAnonymous]
    public class BooksController : ApiController
    {
        private static List<Book> books = new List<Book>()
        {
            new Book { BookId = 1, Title = "Professional C# 5"},
            new Book { BookId = 2, Title = "Professional C# 6"}
        };

        // GET api/values
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/values/5
        public Book Get(int id)
        {
            return books[id];
        }

        // POST api/values
        public void Post([FromBody]Book value)
        {
            books.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Book value)
        {
            books[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            books.RemoveAt(id);
        }
    }
}
