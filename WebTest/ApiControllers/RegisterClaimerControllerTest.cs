using CoreAbstraction;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication4.ApiControllers;

namespace WebTest.ApiControllers
{
    [TestFixture]
    public class RegisterClaimerControllerTest
    {
        RegisterClaimerController controller;
        RegisterClaimerData registerClaimer;

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void ShouldReturnOkForProperRequest()
        {
            registerClaimer = new FakeRegisterClaimerData();
            controller = new RegisterClaimerController(registerClaimer);

            var registerClaimerRequest = new RegisterClaimerRequest()
            {
                ClaimerData = new Person {
                    LastName = "Forest",
                    FirstName = "Gump",
                    MiddleName = "J.",
                    DateOfBirth = new DateTime(1979, 4, 10),
                    PassportSeries = "2323",
                    PassportNumber = "234534",
                    PassportDate = new DateTime(2010, 10, 2),
                    Snils = "12334243232"
                }
            };
            var result = controller.Post(registerClaimerRequest);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(HttpResponseMessage)));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ShouldThrowExceptionIfThereIsExceptionDuringRegisterClaimer()
        {
            registerClaimer = new ThrowExceptionWhileRegisterClaimerData();
            controller = new RegisterClaimerController(registerClaimer);
            var registerClaimerRequest = new RegisterClaimerRequest();

            Assert.That(delegate {
                var result = controller.Post(registerClaimerRequest);
            }, Throws.TypeOf<HttpResponseException>());
        }
    }
}
