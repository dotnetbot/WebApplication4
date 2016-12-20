using Models;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.ApiControllers;
using WebApplication4.ViewModels;

namespace WebTest.ApiControllers
{
    [TestFixture]
    public class RegisterClaimControllerTest
    {
        RegisterClaimController controller;

        [SetUp]
        public void SetUp()
        {
            //controller = new ClaimsController();
        }

        [Test]
        public void ShouldReturnOkForProperRequest()
        {
            var registerClaim = new FakeRegisterClaim();
            var claimDateProvider = new FakeClaimDateProvider();
            controller = new RegisterClaimController(registerClaim, claimDateProvider);

            var viewModel = new CreateClaimViewModel()
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
                PersonId = Guid.NewGuid()
            };

            var result = controller.Post(viewModel);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(HttpResponseMessage)));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ShouldThrowExceptionIfThereIsExceptionDuringRegisterClaim()
        {
            var registerClaim = new ThrowExceptionWhileRegisterClaim();
            var claimDateProvider = new FakeClaimDateProvider();
            controller = new RegisterClaimController(registerClaim, claimDateProvider);
            var viewModel = new CreateClaimViewModel();

            Assert.That(delegate {
                var result = controller.Post(viewModel);
            }, Throws.TypeOf<HttpResponseException>());
        }
    }
}
