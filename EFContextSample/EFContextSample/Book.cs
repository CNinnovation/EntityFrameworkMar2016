using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFContextSample
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }

        [ConcurrencyCheck]
        public string Title { get; set; }
        public string Publisher { get; set; }

        public virtual ICollection<Author> Authors { get; private set; }

    }
}
