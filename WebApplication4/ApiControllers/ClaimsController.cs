using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using Models;
using WebApplication4.ViewModels;
using System;
using System.Data.Entity.Validation;
using WebApplication4.Infrastructure;

namespace WebApplication4.ApiControllers
{
    public class ClaimsController : ApiController
    {
        private readonly Guid RegisterStateId = new Guid("ec402ebb-9516-e611-aaf8-38607729f0cd");
        private readonly Guid RejectStateId = new Guid("ed402ebb-9516-e611-aaf8-38607729f0cd");
        private readonly Guid InworkStateId = new Guid("ee402ebb-9516-e611-aaf8-38607729f0cd");

        private ApplicationDbContext _context;
        private ClaimPresenter _claimPresenter;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
            _claimPresenter = new ClaimPresenter();
        }

        // GET: api/Claims
        public IHttpActionResult GetRegistered()
        {
            return Ok(_context.Claims.Where(c => c.StateId == RegisterStateId).Select(c => new ClaimViewModel
            {
                Id = c.Id,
                Inn = c.Inn,
                RegAddress = c.RegAddress,
                PostAddress = c.PostAddress,
                Job = c.Job,
                JobSphere = c.JobSphere,
                Position = c.Position,
                FamilyIncome = c.FamilyIncome,
                PersonalIncome = c.PersonalIncome,
                Ownership = c.Ownership,
                Email = c.Email,
                Phone = c.Phone,
                DateTime = c.DateTime.Value
            }));
        }

        [Route("api/claims/getrejected")]
        [HttpGet]
        public IHttpActionResult GetRejected()
        {
            return Ok(_context.Claims.Where(c => c.StateId == RejectStateId).Select(c => _claimPresenter.Present(c)));
        }

        [Route("api/claims/getinwork")]
        [HttpGet]
        public IHttpActionResult GetInwork()
        {
            return Ok(_context.Claims.Where(c => c.StateId == InworkStateId).Select(c => _claimPresenter.Present(c)));
        }

        // GET: api/Claims/5
        public IHttpActionResult Get(Guid id)
        {
            var claim = _context.Claims.SingleOrDefault(c => c.Id == id);

            _context.Entry(claim).Collection(c => c.Scans).Load();

            //var result = new ClaimViewModel
            //{
            //    Id = claim.Id,
            //    Inn = claim.Inn,
            //    RegAddress = claim.RegAddress,
            //    PostAddress = claim.PostAddress,
            //    Job = claim.Job,
            //    JobSphere = claim.JobSphere,
            //    Position = claim.Position,
            //    FamilyIncome = claim.FamilyIncome,
            //    PersonalIncome = claim.PersonalIncome,
            //    Ownership = claim.Ownership,
            //    Email = claim.Email,
            //    Phone = claim.Phone,
            //    DateTime = claim.DateTime,
            //    PersonId = claim.PersonId,
            //    StateId = claim.StateId,
            //    IsRejected = claim.StateId == RejectStateId,
            //    Inwork = claim.StateId == InworkStateId
            //};

            //result.Scans.AddRange(claim.Scans.Select(s => new ScanViewModel { Id = s.Id, CreateDate = s.CreateDate, OriginalName = s.OriginalName }));

            return Ok(_claimPresenter.Present(claim));
        }

        [Route("api/claims/getbyperson/{personId}")]
        public IHttpActionResult GetByPerson(Guid personId)
        {
            return Ok(_context.Claims.Where(c => c.PersonId == personId).Select(c => _claimPresenter.Present(c)));
        }

        // POST: api/Claims
        //public IHttpActionResult Post([FromBody]CreateClaimViewModel model)
        //{
        //    //Person person = null;
        //    ////if it is new person then add him
        //    //if (!model.PersonId.HasValue)
        //    //{
        //    //    person = new Person
        //    //    {
        //    //        FirstName = model.FirstName,
        //    //        LastName = model.LastName,
        //    //        MiddleName = model.MiddleName,
        //    //        DateOfBirth = model.DateOfBirth,
        //    //        Snils = model.Snils,
        //    //        PassportSeries = RemoveAllExcessChars(model.PassportSeries),
        //    //        PassportNumber = RemoveAllExcessChars(model.PassportNumber),
        //    //        PassportDate = model.PassportDate,
        //    //        Claims = new List<ClaimData>()
        //    //    };
        //    //    _context.People.Add(person);
        //    //}
        //    //else
        //    //{
        //    //    person = _context.People.SingleOrDefault(p => p.Id == model.PersonId.Value);
        //    //}

        //    var registerClaimRequest = new RegisterClaimRequest()
        //    {
        //        ClaimerId = model.PersonId.Value,
        //        ClaimData = new ClaimData
        //        {
        //            Inn = model.Inn,
        //            RegAddress = model.RegAddress,
        //            PostAddress = model.PostAddress,
        //            Job = model.Job,
        //            JobSphere = model.JobSphere,
        //            Position = model.Position,
        //            FamilyIncome = model.FamilyIncome,
        //            PersonalIncome = model.PersonalIncome,
        //            Ownership = model.Ownership,
        //            Email = model.Email,
        //            Phone = model.Phone,
        //            DateTime = DateTime.Now,
        //            StateId = RegisterStateId
        //        }
        //    }

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch(DbEntityValidationException e)
        //    {
        //        throw e;
        //    }
        //    return Ok(claim.Id);
        //}
                
        [Route("api/claims/reject")]
        [HttpPost]
        public IHttpActionResult Reject(RejectViewModel viewModel)
        {
            var claim = _context.Claims.SingleOrDefault(c => c.Id == viewModel.ClaimId);
            if (claim == null)
            {
                return NotFound();
            }
            var cause = _context.RejectCauses.SingleOrDefault(c => c.Id == viewModel.CauseId);
            if (cause == null)
            {
                return NotFound();
            }
            claim.StateId = RejectStateId;
            _context.SaveChanges();
            return Ok(claim);
        }

        [Route("api/claims/goinwork")]
        [HttpPost]
        public IHttpActionResult GoInwork(InworkViewModel viewModel)
        {
            var claim = _context.Claims.SingleOrDefault(c => c.Id == viewModel.ClaimId);
            if (claim == null)
            {
                return NotFound();
            }

            claim.StateId = InworkStateId;
            _context.SaveChanges();

            return Ok(_claimPresenter.Present(claim));
        }

        private string RemoveAllExcessChars(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            var normString = str.Trim().Replace(" ", "");
            return normString;
        }
    }
}
