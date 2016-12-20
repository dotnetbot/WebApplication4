using Core;
using CoreAbstraction;
using Models;
using NUnit.Framework;
using System;

namespace CoreTest
{
    [TestFixture]
    public class SqlRegisterClaimTest
    {
        SqlRegisterClaim registerClaim;

        [SetUp]
        public void SetUp()
        {
            var repositoryFactory = new FakeRepositoryFactory();
            registerClaim = new SqlRegisterClaim(repositoryFactory);
        }

        [Test]
        public void ShouldThrowExceptionIfRequestDoesNotHaveClaimData()
        {
            var request = new RegisterClaimRequest(Guid.NewGuid(), null, null);
            Assert.That(delegate
            {
                registerClaim.Execute(request);
            }, Throws.TypeOf<RegisterClaimException>());
        }

        [Test]
        public void ShouldThrowExceptionIfRequestDoesNotHaveClaimerId()
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
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };
            var claimDateProvider = new NowClaimDateProvider();

            var request = new RegisterClaimRequest(Guid.Empty, claimData, claimDateProvider);

            Assert.That(delegate
            {
                registerClaim.Execute(request);
            }, Throws.TypeOf<RegisterClaimException>());
        }

        [Test]
        public void ShouldThrowExceptionIfThereIsNoPersonWithThatPersonId()
        {
            var repositoryFactory = new EveryTimeReturnsNullRepositoryFactory();
            registerClaim = new SqlRegisterClaim(repositoryFactory);

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
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };
            var claimDateProvider = new NowClaimDateProvider();

            var request = new RegisterClaimRequest(Guid.NewGuid(), claimData, claimDateProvider);

            Assert.That(delegate
            {
                registerClaim.Execute(request);
            }, Throws.TypeOf<RegisterClaimException>());
        }

        [Test]
        public void ShouldReturnRegisteredClaim()
        {
            registerClaim = new SqlRegisterClaim(new FakePersonsRepositoryFactory());
            var claimerId = Guid.Parse("931B4569-F92D-E611-80B3-3C4A92F56376");
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
                DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
                CategoryId = 1,
                ProgramId = 1
            };
            var claimDateProvider = new NowClaimDateProvider();
            var request = new RegisterClaimRequest(claimerId, claimData, claimDateProvider);

            var claim = registerClaim.Execute(request);
            Assert.That(claim, Is.InstanceOf<ClaimData>());
            Assert.That(claim.StateId, Is.EqualTo(ClaimState.Registered));
        }
    }
}
