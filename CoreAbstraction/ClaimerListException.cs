using System;
using System.Runtime.Serialization;

namespace CoreAbstraction
{
    [Serializable]
    public class ClaimerListException : Exception
    {
        public ClaimerListException()
        {
        }

        public ClaimerListException(string message) : base(message)
        {
        }

        public ClaimerListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClaimerListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}