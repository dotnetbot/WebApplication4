using NUnit.Framework;
using Core;
using Models;
using System;

namespace CoreTest
{
    [TestFixture]
    public class SqlRegisterClaimerDataTest
    {
        SqlRegisterClaimerData registerClaimerData;
        
        [SetUp]
        public void SetUp()
        {
            var repositoryFactory = new FakeRepositoryFactory();
            registerClaimerData = new SqlRegisterClaimerData(repositoryFactory);
        }

        

        //[Test]
        //public void ShouldReturnIdAfterRegistring()
        //{
        //    var request = new RegisterClaimerRequest
        //    {
        //        ClaimerData = new Person
        //        {
        //            LastName = "Forest",
        //            FirstName = "Gump",
        //            MiddleName = "J.",
        //            DateOfBirth = new DateTime(1979, 4, 10),
        //            PassportSeries = "2323",
        //            PassportNumber = "234534",
        //            PassportDate = new DateTime(2010, 10, 2),
        //            Snils = "12334243232"
        //        }
        //    };
        //    Guid claimerId = registerClaimerData.Execute(request);
        //    Assert.That(claimerId, Is.Not.EqualTo(Guid.Empty));
        //}
    }
}
