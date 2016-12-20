using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace WebApplication4.ViewModels
{
    public class ClaimViewModel
    {
        public ClaimViewModel()
        {
            Scans = new List<ScanViewModel>();
        }

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
        public DateTime? DateTime { get; set; }
        public Guid PersonId { get; set; }
        public Guid StateId { get; set; }
        public bool IsRejected { get; set; }
        public bool Inwork { get; set; }

        public List<ScanViewModel> Scans { get; set; }
    }
}