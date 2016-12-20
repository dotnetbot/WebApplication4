using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApplication4.Infrastructure;
using Models;
using WebApplication4.ViewModels;

namespace WebTest.Infrastructure
{
    [TestFixture]
    public class ClaimerPresenterTest
    {
        ClaimerPresenter claimerPresenter;

        [Test]
        public void ShouldPresentClaimerAsClaimerViewModel()
        {
            claimerPresenter = new ClaimerPresenter();

            var person = new Person()
            {
                Id = Guid.Parse("ceadf561-2c0d-e611-aaf6-38607729f0cd"),
                LastName = "Богданова",
                FirstName = "Регина",
                MiddleName = "Фанилевна",
                DateOfBirth = new DateTime(1980, 3, 15),
                PassportDate = new DateTime(2010, 11, 5),
                PassportNumber = "342343",
                PassportSeries = "3432",
                Snils = "13560032723"
            };

            var viewModel = claimerPresenter.Present(person);

            Assert.That(viewModel, Is.InstanceOf<ClaimerViewModel>());
        }

        [Test]
        public void ShouldPresentClaimer()
        {
            claimerPresenter = new ClaimerPresenter();

            var person = new Person()
            {
                Id = Guid.Parse("ceadf561-2c0d-e611-aaf6-38607729f0cd"),
                LastName = "Богданова",
                FirstName = "Регина",
                MiddleName = "Фанилевна",
                DateOfBirth = new DateTime(1980, 3, 15),
                PassportDate = new DateTime(2010, 11, 5),
                PassportNumber = "342343",
                PassportSeries = "3432",
                Snils = "13560032723"
            };

            var viewModel = claimerPresenter.Present(person);

            Assert.That(viewModel.Id, Is.EqualTo("ceadf561-2c0d-e611-aaf6-38607729f0cd"));
            Assert.That(viewModel.LastName, Is.EqualTo("Богданова"));
            Assert.That(viewModel.FirstName, Is.EqualTo("Регина"));
            Assert.That(viewModel.MiddleName, Is.EqualTo("Фанилевна"));
            Assert.That(viewModel.DateOfBirth, Is.EqualTo(new DateTime(1980, 3, 15)));
            Assert.That(viewModel.PassportDate, Is.EqualTo(new DateTime(2010, 11, 5)));
            Assert.That(viewModel.PassportNumber, Is.EqualTo("342343"));
            Assert.That(viewModel.PassportSeries, Is.EqualTo("3432"));
            Assert.That(viewModel.Snils, Is.EqualTo("13560032723"));
        }
    }
}
