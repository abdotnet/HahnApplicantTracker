using Hahn.ApplicatonProcess.December2020.Domain.Contracts.V1.Requests;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicantRequestExample : IExamplesProvider<ApplicantRequest>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ApplicantRequest GetExamples()
        {
            return new ApplicantRequest
            {
                Address = "Main Street Grand Canal Way Royal Canal Way",
                Age = 26,
                CountryOfOrigin = "UK",
                EmailAddress = "abudotnet@gmai.com",
                FamilyName = "Ahmann",
                Hired = true,
                Name = "Adele"
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ApplicantUpdateRequestExample : IExamplesProvider<ApplicantUpdateRequest>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ApplicantUpdateRequest GetExamples()
        {
            return new ApplicantUpdateRequest
            {
                Address = "Lagos ketun road Canal off ghana way",
                Age = 56,
                CountryOfOrigin = "United",
                EmailAddress = "success@inhahntest.com",
                FamilyName = "Terry",
                Hired = true,
                Name = "Curry",
                ID = 1
            };
        }
    }
}
