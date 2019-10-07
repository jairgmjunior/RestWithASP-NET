using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Models
{
    public class Book
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Altor { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
