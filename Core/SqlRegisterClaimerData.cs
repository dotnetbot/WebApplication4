using System;
using System.Runtime.Serialization;
using Models;
using CoreAbstraction;

namespace Core
{
    public class SqlRegisterClaimerData: RegisterClaimerData
    {
        private IRepositoryFactory _repositoryFactory;

        public SqlRegisterClaimerData(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public Guid Execute(RegisterClaimerRequest request)
        {
            try
            {
                var claimerDataValidator = new ClaimerDataValidator();            
                claimerDataValidator.Validate(request.ClaimerData);
                var id = Save(request.ClaimerData);
                return id;
            }
            catch (Exception e)
            {
                throw new RegisterClaimerException("An error has occured during registring claimers data", e);
            }
        }

        private Guid Persist(Person claimerData)
        {
            //var claimerData = claimer.MakePersistanceData();

            using (var repository = _repositoryFactory.MakeRepository())
            {
                repository.Add(claimerData);
                repository.Save();
            }
            return claimerData.Id;
        }

        private Guid Save(Person claimerData)
        {
            try
            {
                return Persist(claimerData);
            }
            catch (Exception e)
            {
                throw new ClaimerPersistanceException("An error has been occured during persisting claimers data", e);
            }
        }

        [Serializable]
        public class ClaimerPersistanceException : Exception
        {
            public ClaimerPersistanceException()
            {
            }

            public ClaimerPersistanceException(string message) : base(message)
            {
            }

            public ClaimerPersistanceException(Exception e): this("", e)
            {
            }

            public ClaimerPersistanceException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ClaimerPersistanceException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}