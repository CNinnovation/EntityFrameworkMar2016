using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("client - wait for server to start");
            Console.ReadLine();
            GetSample();
            Console.WriteLine("Main, wait for answer");
            Console.ReadLine();
        }

        private static async void GetSample()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:3782/api/books");
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }

        }
    }
}
