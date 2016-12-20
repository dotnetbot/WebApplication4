using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApplication4.ApiControllers;
using CoreAbstraction;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebTest.ApiControllers
{
    [TestFixture]
    public class ClaimersControllerTest
    {
        ClaimersController claimersController;

        [Test]
        public void ShouldReturnOkResponseForProperRequest()
        {
            var claimerList = new MockClaimersList(
                new List<Models.Person> {
                    new Models.Person {
                        Id = Guid.Parse("C7ADF561-2C0D-E611-AAF6-38607729F0CD"),
                        FirstName = "Оксана",
                        LastName = "Желнова",
                        MiddleName = "Юрьевна",
                        DateOfBirth = new DateTime(1980, 5, 1),
                        Snils = "12671109641",
                        PassportSeries = "8001",
                        PassportNumber = "344626",
                        PassportDate = new DateTime(2006, 11, 5)
                    }
                }
                );
            claimersController = new ClaimersController(claimerList);

            var result = claimersController.Get();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(HttpResponseMessage)));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var contentResult = result.Content.ReadAsStringAsync().Result;
            Assert.That(contentResult, Is.EqualTo("[{\"id\":\"c7adf561-2c0d-e611-aaf6-38607729f0cd\",\"lastName\":\"Желнова\",\"firstName\":\"Оксана\",\"middleName\":\"Юрьевна\",\"dateOfBirth\":\"1980-05-01T00:00:00\",\"snils\":\"12671109641\",\"passportSeries\":\"8001\",\"passportNumber\":\"344626\",\"passportDate\":\"2006-11-05T00:00:00\"}]"));
        }

        [Test]
        public void ShouldReturnOkResponseForEmptyList()
        {
            var claimerList = new EmptyClaimersList();
            claimersController = new ClaimersController(claimerList);

            var result = claimersController.Get();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(HttpResponseMessage)));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));            
        }

        [Test]
        public void ShouldThrowExceptionIfThereIsExceptionInClaimerList()
        {
            var claimerList = new ErrorClaimerList();
            claimersController = new ClaimersController(claimerList);            

            Assert.That(delegate {
                var result = claimersController.Get();
            }, Throws.TypeOf<HttpResponseException>());
        }
    }
}
