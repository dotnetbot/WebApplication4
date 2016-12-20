using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.ViewModels;

namespace WebApplication4.Infrastructure
{
    public class ClaimPresenter
    {
        public ClaimPresenter()
        {

        }

        public ClaimViewModel Present(ClaimData claimData)
        {
            var viewModel = new ClaimViewModel() {
                Id = claimData.Id,
                Inn = claimData.Inn,
                RegAddress = claimData.RegAddress,
                PostAddress = claimData.PostAddress,
                Job = claimData.Job,
                JobSphere = claimData.JobSphere,
                Position = claimData.Position,
                FamilyIncome = claimData.FamilyIncome,
                PersonalIncome = claimData.PersonalIncome,
                Ownership = claimData.Ownership,
                Email = claimData.Email,
                Phone = claimData.Phone,

                DateTime = claimData.DateTime
            };

            //if (_claimData.DateTime.HasValue)
            //    viewModel.DateTime = _cla

            return viewModel;
        }
    }
}