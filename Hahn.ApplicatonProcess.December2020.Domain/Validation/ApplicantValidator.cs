using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validation
{
   public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).NotNull().MinimumLength(5);    
            RuleFor(applicant => applicant.FamilyName).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).NotNull().MinimumLength(10);
            RuleFor(applicant => applicant.CountryOfOrigin).NotNull().MinimumLength(10);
            RuleFor(applicant => applicant.Age).NotNull().ExclusiveBetween(20, 60);
            RuleFor(applicant => applicant.EmailAddress).NotEmpty().WithMessage("Email address is required ")
                .EmailAddress().WithMessage("The email must be a valid email address");

            
        }
    }
}
