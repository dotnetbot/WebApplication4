using Core;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest
{
    [TestFixture]
    public class ClaimDataValidatorTest
    {
        ClaimDataValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new ClaimDataValidator();
        }

        [Test]
        public void ShouldBeInvalidIfNoInn()
        {
            var claimData = new ClaimData()
            {
                //Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoRegAddress()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                //RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoPostAddress()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                //PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoJob()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                //Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoJobSphere()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                //JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoPostion()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                //Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoFamilyIncome()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                //FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoPersonalIncome()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                //PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoOwnership()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                //Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoPhone()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                //Phone = "9177777777",
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoCategoryId()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                //DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                //CategoryId = 1,
                ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldBeInvalidIfNoProgramId()
        {
            var claimData = new ClaimData()
            {
                Inn = "234123219879",
                RegAddress = "г. Уфа",
                PostAddress = "Ufa",
                Job = "ООО Башнефть",
                JobSphere = "Нефть",
                Position = "генеральный директор",
                FamilyIncome = "500000",
                PersonalIncome = "400000",
                Ownership = "Дом",
                Email = "gendir@bashneft.ru",
                Phone = "9177777777",
                //DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                //ProgramId = 1
            };

            var result = validator.IsValid(claimData);
            Assert.That(result, Is.False);
        }
    }
}
