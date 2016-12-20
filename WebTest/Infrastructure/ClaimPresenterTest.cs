using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Infrastructure;
using WebApplication4.ViewModels;

namespace WebTest.Infrastructure
{
    [TestFixture]
    public class ClaimPresenterTest
    {
        ClaimPresenter claimPresenter;

        [Test]
        public void ShouldPresentClaim()
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

            claimPresenter = new ClaimPresenter();
            var viewModel = claimPresenter.Present(claimData);
            Assert.That(viewModel, Is.InstanceOf<ClaimViewModel>());

            Assert.That(viewModel.Inn, Is.EqualTo("234123219879"));
            Assert.That(viewModel.RegAddress, Is.EqualTo("г. Уфа"));
            Assert.That(viewModel.PostAddress, Is.EqualTo("Ufa"));
            Assert.That(viewModel.Job, Is.EqualTo("ООО Башнефть"));
            Assert.That(viewModel.JobSphere, Is.EqualTo("Нефть"));
            Assert.That(viewModel.Position, Is.EqualTo("генеральный директор"));
            Assert.That(viewModel.FamilyIncome, Is.EqualTo("500000"));
            Assert.That(viewModel.PersonalIncome, Is.EqualTo("400000"));
            Assert.That(viewModel.Ownership, Is.EqualTo("Дом"));
            Assert.That(viewModel.Email, Is.EqualTo("gendir@bashneft.ru"));
            Assert.That(viewModel.Phone, Is.EqualTo("9177777777"));
            Assert.That(viewModel.DateTime, Is.EqualTo(new DateTime(2016, 07, 28, 17, 35, 59)));
            //Assert.That(viewModel.CategoryId, Is.EqualTo(1));
            //Assert.That(viewModel.ProgramId, Is.EqualTo(1));
        }

        //[Test]
        //public void ShouldPresentNullDateIfNoDateTime()
        //{
        //    var claimData = new ClaimData()
        //    {
        //        Inn = "234123219879",
        //        RegAddress = "г. Уфа",
        //        PostAddress = "Ufa",
        //        Job = "ООО Башнефть",
        //        JobSphere = "Нефть",
        //        Position = "генеральный директор",
        //        FamilyIncome = "500000",
        //        PersonalIncome = "400000",
        //        Ownership = "Дом",
        //        Email = "gendir@bashneft.ru",
        //        Phone = "9177777777",
        //        //DateTime = new DateTime(2016, 07, 28, 17, 35, 59),
        //        CategoryId = 1,
        //        ProgramId = 1
        //    };

        //    claimPresenter = new ClaimPresenter(claimData);
        //    var viewModel = claimPresenter.Present();
        //    Assert.That(viewModel, Is.InstanceOf<ClaimViewModel>());

        //    Assert.That(viewModel.Inn, Is.EqualTo("234123219879"));
        //    Assert.That(viewModel.RegAddress, Is.EqualTo("г. Уфа"));
        //    Assert.That(viewModel.PostAddress, Is.EqualTo("Ufa"));
        //    Assert.That(viewModel.Job, Is.EqualTo("ООО Башнефть"));
        //    Assert.That(viewModel.JobSphere, Is.EqualTo("Нефть"));
        //    Assert.That(viewModel.Position, Is.EqualTo("генеральный директор"));
        //    Assert.That(viewModel.FamilyIncome, Is.EqualTo("500000"));
        //    Assert.That(viewModel.PersonalIncome, Is.EqualTo("400000"));
        //    Assert.That(viewModel.Ownership, Is.EqualTo("Дом"));
        //    Assert.That(viewModel.Email, Is.EqualTo("gendir@bashneft.ru"));
        //    Assert.That(viewModel.Phone, Is.EqualTo("9177777777"));
        //    Assert.That(viewModel.DateTime, Is.Null);
        //}
    }
}
