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
    public class SqlClaimerListTest
    {
        SqlClaimerList claimerList;

        [Test]
        public void ShouldReturListOfPerson()
        {
            var items = new List<Person>();
            items.Add(new Person() { Id = Guid.Parse("cdadf561-2c0d-e611-aaf6-38607729f0cd") });
            items.Add(new Person() { Id = Guid.Parse("ceadf561-2c0d-e611-aaf6-38607729f0cd") });
            items.Add(new Person() { Id = Guid.Parse("cfadf561-2c0d-e611-aaf6-38607729f0cd") });

            var repositoryFactory = new CustomisableRepositoryFactory<Person>(items);

            claimerList = new SqlClaimerList(repositoryFactory);
            var result = claimerList.Get();

            Assert.That(result, Is.InstanceOf<List<Person>>());
        }

        [Test]
        public void ShouldReturnSameAmountAsInRepository()
        {
            var items = new List<Person>();
            items.Add(new Person() { Id = Guid.Parse("cdadf561-2c0d-e611-aaf6-38607729f0cd") });
            items.Add(new Person() { Id = Guid.Parse("ceadf561-2c0d-e611-aaf6-38607729f0cd") });
            items.Add(new Person() { Id = Guid.Parse("cfadf561-2c0d-e611-aaf6-38607729f0cd") });

            var repositoryFactory = new CustomisableRepositoryFactory<Person>(items);

            claimerList = new SqlClaimerList(repositoryFactory);

            var persons = claimerList.Get();

            Assert.That(persons.Count(), Is.EqualTo(3));
        }
    }
}
