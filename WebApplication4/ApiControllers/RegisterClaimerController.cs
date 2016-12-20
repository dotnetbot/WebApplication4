using CoreAbstraction;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApplication4.ApiControllers
{
    public class RegisterClaimerController : ApiController
    {
        private RegisterClaimerData _registerClaimer;
        public RegisterClaimerController(RegisterClaimerData registerClaimer)
        {
            _registerClaimer = registerClaimer;
        }

        public HttpResponseMessage Post(RegisterClaimerRequest registerClaimerRequest)
        {
            HttpResponseMessage response;
            Guid claimerId;
            try
            {
                claimerId = _registerClaimer.Execute(registerClaimerRequest);
            }
            catch(RegisterClaimerException e)
            {
                response = BadRequest(e);
                throw new HttpResponseException(response);
            }

            response = OkObject<Guid>(claimerId);

            return response;
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
