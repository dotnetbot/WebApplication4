using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Scan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string OriginalName { get; set; }

        public Guid ClaimId { get; set; }
        public ClaimData Claim { get; set; }

        private string _extWithDot;
        [NotMapped]
        public string ExtensionWithDot
        {
            get
            {
                if (OriginalName.IndexOf('.') > 0 && string.IsNullOrEmpty(_extWithDot))
                {
                    _extWithDot = OriginalName.Substring(OriginalName.IndexOf('.'));
                }
                return _extWithDot;
            }
        }

        private string _localFileName;
        [NotMapped]
        public string LocalFileName
        {
            get
            {
                if (Id != null && string.IsNullOrEmpty(_localFileName))
                {
                    _localFileName = Id.ToString() + ExtensionWithDot;
                }

                return _localFileName;
            }
        }
    }
}
