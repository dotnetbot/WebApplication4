using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreAbstraction
{
    [Serializable]
    public class RegisterClaimerException : Exception
    {
        public RegisterClaimerException()
        {
        }

        public RegisterClaimerException(string message) : base(message)
        {
        }

        public RegisterClaimerException(Exception e) : this("", e)
        {
        }

        public RegisterClaimerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegisterClaimerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
