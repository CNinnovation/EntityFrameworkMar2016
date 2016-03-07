using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsDemo
{
    [Table("Books")]
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(20)]
        public string Publisher { get; set; }

        public string Isbn { get; set; }

        public ICollection<Author> Authors { get; set; }

    }
}
