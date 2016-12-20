using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.ViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Snils { get; set; }

        public string PassportSeries { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportDate { get; set; }
    }
}