using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Building
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}