using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CoreAbstraction;

namespace Core
{
    public class Claim: IClaim
    {
        private ClaimData data;
        private Guid _state;
        public Guid State
        {
            get
            {
                return _state;
            }
            set
            {
                if (value == Guid.Empty)
                    throw new EmptyStateException();

                if (_state == Guid.Empty && value == ClaimState.Inwork)
                    throw new InvalidStateOrderException();

                _state = value;
            }
        }

        public Guid Id { get; private set; }

        //public static Claim Make(Guid id, ClaimData claimData)
        //{
        //    var claimDataValidator = new ClaimDataValidator();
        //    if (!claimDataValidator.IsValid(claimData))
        //        throw new InvalidClaimDataException();

        //    return new Claim(id, claimData);
        //}

        //private static bool IsValid(ClaimData claimData)
        //{
        //    return claimData.ProgramId != 0 && claimData.CategoryId != 0;
        //}

        public Claim(Guid claimerId, ClaimData claimData)
        {
            data = claimData;
            data.PersonId = claimerId;
        }

        public class InvalidClaimDataException : Exception
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

        [Serializable]
        public class EmptyStateException : Exception
        {
            public EmptyStateException()
            {
            }

            public EmptyStateException(string message) : base(message)
            {
            }

            public EmptyStateException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected EmptyStateException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        public class InvalidStateOrderException : Exception
        {
            public InvalidStateOrderException()
            {
            }

            public InvalidStateOrderException(string message) : base(message)
            {
            }

            public InvalidStateOrderException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidStateOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
