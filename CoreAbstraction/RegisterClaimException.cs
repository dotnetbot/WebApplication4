using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreAbstraction
{
    [Serializable]
    public class RegisterClaimException : Exception
    {
        public RegisterClaimException()
        {
        }

        public RegisterClaimException(string message) : base(message)
        {
        }

        public RegisterClaimException(Exception e) : this("", e)
        {
        }

        public RegisterClaimException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegisterClaimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
