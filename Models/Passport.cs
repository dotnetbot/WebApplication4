using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Passport
    {
        public int Id { get; set; }

        [Required, MaxLength(4)]
        public string Series { get; set; }

        [Required, MaxLength(6)]
        public string Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}