using Core;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Claimer;

namespace CoreTest
{
    [TestFixture]
    public class ClaimerTest
    {
        Claimer claimer;

        [SetUp]
        public void SetUp()
        {
            var personData = new Person
            {
                LastName = "Forest",
                FirstName = "Gump",
                MiddleName = "J.",
                DateOfBirth = new DateTime(1979, 4, 10),
                PassportSeries = "2323",
                PassportNumber = "234534",
                PassportDate = new DateTime(2010, 10, 2),
                Snils = "12334243232"
            };
            var id = Guid.NewGuid();

            claimer = new Claimer(id, personData);
        }

        [Test]
        public void ShouldHasNotEmptyId()
        {
            Assert.That(claimer.Id, Is.Not.EqualTo(Guid.Empty));
        }
        
        [Test]
        public void ShouldThrowExceptionOnValidationIfClaimerDataIsInvalid()
        {
            var invalidPersonData = new Person
            {
                LastName = "",
                FirstName = "",
                MiddleName = ""
            };

            Assert.That(delegate
            {
                Claimer.Validate(invalidPersonData);
            }, Throws.TypeOf<InvalidClaimerDataException>());

        }        

        [Test]
        public void ShouldCanMakeClaim()
        {            
            var claimData = new ClaimData
            {
                ProgramId = 1,
                CategoryId = 1
            };
            var claim = claimer.MakeClaim(claimData);

            Assert.That(claim, Is.Not.Null);
        }
    }
}
