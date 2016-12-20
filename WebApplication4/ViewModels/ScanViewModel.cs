using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.ViewModels
{
    public class ScanViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string OriginalName { get; set; }
    }
}