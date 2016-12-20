using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Models;
using Core;

namespace CoreTest
{
    [TestFixture]
    public class ClaimTest
    {
        Claim claim;

        [SetUp]
        public void SetUp()
        {
            var claimData = new ClaimData
            {
                ProgramId = 1,
                CategoryId = 1
            };
            claim = Claim.Make(claimData);
        }

        [Test]
        public void ShouldThrowExceptionIfClaimDataIsInvalid()
        {
            Assert.That(delegate {
                Claim.Make(new ClaimData());
            }, Throws.TypeOf<Claim.InvalidClaimDataException>());
        }

        [Test]
        public void ShouldMakeClaimWithValidProperties()
        {
            Assert.That(claim, Is.Not.Null);
        }

        [Test]
        public void StateCanNotBeEmpty()
        {
            Assert.That(delegate {
                claim.State = Guid.Empty;
            }, Throws.TypeOf<Claim.EmptyStateException>());
        }

        [Test]
        public void FirstStateCanNotBeInwork()
        {
            Assert.That(delegate {
                claim.State = ClaimState.Inwork;
            }, Throws.TypeOf<Claim.InvalidStateOrderException>());
        }

        [Test]
        public void FirstStateCanBeRegistered()
        {
            claim.State = ClaimState.Registered;
            Assert.That(claim.State, Is.EqualTo(ClaimState.Registered));
        }

        [Test]
        public void FirstStateCanBeRejected()
        {
            claim.State = ClaimState.Rejected;
            Assert.That(claim.State, Is.EqualTo(ClaimState.Rejected));
        }
    }
}
