using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Models;
using Core;
using static Core.ClaimerDataValidator;

namespace CoreTest
{
    /// <summary>
    /// Summary description for ClaimerDataValidatorTest
    /// </summary>
    [TestFixture]
    public class ClaimerDataValidatorTest
    {
        ClaimerDataValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new ClaimerDataValidator();
        }

        [Test]
        public void ShouldBeInvalidIfNoLastName()
        {
            var invalidPersonData = new Person
            {
                LastName = "",
                FirstName = "Forest",
                MiddleName = "J."
            };

            var result = validator.IsValid(invalidPersonData);

            Assert.That(result, Is.False);
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
                validator.Validate(invalidPersonData);
            }, Throws.TypeOf<InvalidClaimerDataException>());

        }
    }
}
