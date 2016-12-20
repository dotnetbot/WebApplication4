using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.ViewModels;
using Models;

namespace WebApplication4.Infrastructure
{
    public class ClaimerPresenter
    {
        public ClaimerViewModel Present(Person claimer)
        {
            return new ClaimerViewModel() {
                Id = claimer.Id.ToString(),
                LastName = claimer.LastName,
                FirstName = claimer.FirstName,
                MiddleName = claimer.MiddleName,
                DateOfBirth = claimer.DateOfBirth,
                PassportDate = claimer.PassportDate,
                PassportNumber = claimer.PassportNumber,
                PassportSeries = claimer.PassportSeries,
                Snils = claimer.Snils
            };
        }
    }
}