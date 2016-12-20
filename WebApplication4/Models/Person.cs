using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(11)]
        public string Snils { get; set; }

        [Required, MaxLength(4)]
        public string PassportSeries { get; set; }

        [Required, MaxLength(6)]
        public string PassportNumber { get; set; }

        [Required]
        public DateTime PassportDate { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}