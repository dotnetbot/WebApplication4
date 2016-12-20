using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core
{
    public class ClaimDataValidator
    {
        public void Validate(ClaimData claimData)
        {
            throw new InvalidClaimDataException();
        }

        public bool IsValid(ClaimData claimData)
        {
            return !string.IsNullOrWhiteSpace(claimData.Inn)
                && !string.IsNullOrWhiteSpace(claimData.RegAddress) 
                && !string.IsNullOrWhiteSpace(claimData.PostAddress) 
                && !string.IsNullOrWhiteSpace(claimData.Job) 
                && !string.IsNullOrWhiteSpace(claimData.JobSphere) 
                && !string.IsNullOrWhiteSpace(claimData.Position) 
                && !string.IsNullOrWhiteSpace(claimData.FamilyIncome) 
                && !string.IsNullOrWhiteSpace(claimData.PersonalIncome) 
                && !string.IsNullOrWhiteSpace(claimData.Ownership)
                && !string.IsNullOrWhiteSpace(claimData.Phone)
                && claimData.CategoryId != 0
                && claimData.ProgramId != 0
                ;
        }

        [Serializable]
        private class InvalidClaimDataException : Exception
        {
            public InvalidClaimDataException()
            {
            }

            public InvalidClaimDataException(string message) : base(message)
            {
            }

            public InvalidClaimDataException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidClaimDataException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
