using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using WebApplication4.ViewModels;

namespace WebApplication4.ApiControllers
{
    //[RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            return _context.People.Select(p => new { p.Id, p.LastName, p.FirstName, p.MiddleName, p.Snils, p.DateOfBirth });
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(Guid id)
        {
            var person = _context.People.SingleOrDefault(p => p.Id == id);

            if (person != null)
                return Ok(new PersonViewModel()
                {
                    Id = person.Id,
                    LastName = person.LastName,
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    DateOfBirth = person.DateOfBirth,
                    PassportSeries = person.PassportSeries,
                    PassportNumber = person.PassportNumber,
                    PassportDate = person.PassportDate,
                    Snils = person.Snils
                });

            return NotFound();
        }

        [Route("api/people/getbysnils")]
        public IHttpActionResult GetBySnils(string snils)
        {
            Person person = null;
            try
            {
                person = _context.People.SingleOrDefault(p => p.Snils == snils);
            }
            catch
            {
                //TODO: What is supposed to do, if more than one? Log it?
                person = _context.People.First(p => p.Snils == snils);
            }
            if (person != null)
                return Ok(new
                {
                    person.Id,
                    person.FirstName,
                    person.LastName,
                    person.MiddleName,
                    person.DateOfBirth,
                    person.Snils,
                    person.PassportSeries,
                    person.PassportNumber,
                    person.PassportDate
                });

            return NotFound();
        }

        [Route("api/people/getbypassport")]
        public IEnumerable<object> GetByPassport([FromUri]PassportViewModel model)
        {
            return _context.People
                .Where(p => p.PassportSeries == model.Series &&
                            p.PassportNumber == model.Number &&
                            p.PassportDate == model.Date)
                .Select(p => new
                {
                    p.Id,
                    p.FirstName,
                    p.LastName,
                    p.MiddleName,
                    p.Snils
                });

            //return new List<object>
            //    {
            //        new
            //            {
            //                id = 3,
            //                firstName = "Федор",
            //                lastName = "Кулешов",
            //                middleName = "Андреевич",
            //                Snils = "13412343223"
            //            }
            //    };
        }

        [Route("api/people/getbyname")]
        public IEnumerable<object> GetByName([FromUri]NameViewModel model)
        {
            return _context.People
                .Where(p => p.LastName == model.LastName &&
                            p.FirstName == model.FirstName &&
                            p.MiddleName == model.MiddleName &&
                            p.DateOfBirth == model.DateOfBirth)
                .Select(p => new
                {
                    p.Id,
                    p.FirstName,
                    p.LastName,
                    p.MiddleName,
                    p.Snils
                });

            //return new List<object>
            //    {
            //        new
            //            {
            //                id = 3,
            //                firstName = "Феываывор",
            //                lastName = "Кдлфв",
            //                middleName = "Андыварыефевыавивч",
            //                Snils = "13412334543"
            //            }
            //    };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}