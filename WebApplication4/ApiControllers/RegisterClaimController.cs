using Core;
using CoreAbstraction;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApplication4.ViewModels;

namespace WebApplication4.ApiControllers
{
    public class RegisterClaimController : ApiController
    {
        RegisterClaim _registerClaim;
        ClaimDateProvider _claimDateProvider;

        public RegisterClaimController(RegisterClaim registerClaim, ClaimDateProvider claimDateProvider)
        {
            _registerClaim = registerClaim;
            _claimDateProvider = claimDateProvider;
        }

        public HttpResponseMessage Post([FromBody]CreateClaimViewModel viewModel)
        {
            HttpResponseMessage response;
            ClaimData claim;
            try
            {
                var registerClaimRequest = CreateRequest(viewModel);
                claim = _registerClaim.Execute(registerClaimRequest);
            }
            catch (Exception e)
            {
                response = BadRequest(e);
                throw new HttpResponseException(response);
            }

            response = OkObject<Guid>(claim.Id);

            return response;
        }

        private RegisterClaimRequest CreateRequest(CreateClaimViewModel model)
        {
            if (!model.PersonId.HasValue)
            {
                throw new RegisterClaimException("There is no personId. PersonId is required");
            }
            var claimData = new ClaimData
            {
                Inn = model.Inn,
                RegAddress = model.RegAddress,
                PostAddress = model.PostAddress,
                Job = model.Job,
                JobSphere = model.JobSphere,
                Position = model.Position,
                FamilyIncome = model.FamilyIncome,
                PersonalIncome = model.PersonalIncome,
                Ownership = model.Ownership,
                Email = model.Email,
                Phone = model.Phone,
                CategoryId = 1,
                ProgramId = 1
            };


            var request = new RegisterClaimRequest(model.PersonId.Value, claimData, _claimDateProvider);
                
            return request;
        }

        private HttpResponseMessage BadRequest(Exception e)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.ReasonPhrase = e.Message;
            return response;
        }

        private HttpResponseMessage OkObject<T>(T o)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<T>(o, new JsonMediaTypeFormatter(), "application/json");
            return response;
        }
    }
}
