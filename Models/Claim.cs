using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Claim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Inn { get; set; }
        public string RegAddress { get; set; }
        public string PostAddress { get; set; }
        public string Job { get; set; }
        public string JobSphere { get; set; }
        public string Position { get; set; }
        public string FamilyIncome { get; set; }
        public string PersonalIncome { get; set; }
        public string Ownership { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime DateTime { get; set; }

        public Guid StateId { get; set; }

        public Guid PersonId { get; set; }

        public ICollection<Scan> Scans { get; set; }
        public Person Owner { get; set; }
    }
}