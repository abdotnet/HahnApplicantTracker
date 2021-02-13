using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Infrastructure;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validation
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        private readonly IHttpServiceHelper _httpService;
        private readonly ILogger<ApplicantValidator> _logger;
        public ApplicantValidator(IHttpServiceHelper httpService, ILogger<ApplicantValidator> logger)
        {
            this._httpService = httpService;
            this._logger = logger;
        }
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.Address).NotNull().MinimumLength(10);
            RuleFor(applicant => applicant.Age).NotNull().ExclusiveBetween(20, 60);
            RuleFor(applicant => applicant.EmailAddress).NotEmpty().NotNull().WithMessage("Email address is required ")
                .EmailAddress().WithMessage("The email must be a valid email address");

            RuleFor(applicant => applicant.EmailAddress).Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(c =>
            {
                this._logger.LogInformation("Email not valid");
                return "Email not valid";
            });

            RuleFor(applicant => applicant.CountryOfOrigin).NotNull().NotEmpty().MustAsync(async (country, cancellation) =>
           {
               string url = InfrastructureDefaults.RestCountryUrl + country;
               string clientResponse = await _httpService.GetHttpClient(url);
               this._logger.LogInformation(clientResponse);
               if (!string.IsNullOrEmpty(clientResponse))
                   return true;

               return false;
           }).WithMessage("Country specified is not valid");

        }


    }
}
