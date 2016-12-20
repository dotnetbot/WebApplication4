using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CoreAbstraction;
using System.Net;
using System.Net.Http;
using Models;
using System.Net.Http.Formatting;
using WebApplication4.ViewModels;
using WebApplication4.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace WebApplication4.ApiControllers
{
    public class ClaimersController: ApiController
    {
        ClaimerList _claimerList;
        ClaimerPresenter presenter;

        public ClaimersController(ClaimerList claimerList)
        {
            _claimerList = claimerList;
            presenter = new ClaimerPresenter();
        }

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            List<ClaimerViewModel> claimerViewModels;

            try
            {
                var claimers = _claimerList.Get();
                claimerViewModels = claimers.Select(presenter.Present).ToList();
            }
            catch (Exception e)
            {
                response = BadRequest(e);
                throw new HttpResponseException(response);
            }

            response = OkObject(claimerViewModels);

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
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Content = new ObjectContent<T>(o, formatter, "application/json");
            return response;
        }
    }
}