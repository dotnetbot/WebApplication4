using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.ViewModels
{
    public class CreateClaimViewModel
    {
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
        //navigation properties
        public Guid? PersonId { get; set; }        
    }
}