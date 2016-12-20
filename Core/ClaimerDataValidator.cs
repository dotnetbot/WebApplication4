using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ClaimerDataValidator
    {
        public void Validate(Person claimerData)
        {
            if (!IsValid(claimerData))
            {
                throw new InvalidClaimerDataException();
            }
        }

        public bool IsValid(Person claimerData)
        {
            return
                !string.IsNullOrWhiteSpace(claimerData.FirstName) &&
                !string.IsNullOrWhiteSpace(claimerData.LastName) &&
                !string.IsNullOrWhiteSpace(claimerData.MiddleName) &&
                !string.IsNullOrWhiteSpace(claimerData.PassportSeries) &&
                !string.IsNullOrWhiteSpace(claimerData.PassportNumber) &&
                claimerData.PassportDate != default(DateTime) &&
                !string.IsNullOrWhiteSpace(claimerData.Snils) &&
                claimerData.DateOfBirth != default(DateTime);
        }

        public class InvalidClaimerDataException : Exception
        {

        }
    }
}
