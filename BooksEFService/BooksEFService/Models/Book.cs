namespace BooksEFService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(20)]
        public string Publisher { get; set; }
    }
}
