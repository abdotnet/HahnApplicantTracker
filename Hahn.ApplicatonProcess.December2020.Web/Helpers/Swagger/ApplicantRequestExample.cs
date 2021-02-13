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
    public class ApplicantRequestExample : IExamplesProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetExamples()
        {
            return new ApplicantRequest
            {
                Address = "Main Street Grand Canal Way Royal Canal Way",
                Age = 26,
                CountryOfOrigin = "UK",
                EmailAddress = "abudotnet@gmai.com",
                FamilyName = "Ahmann",
                Hired = true,
                Name = "Adel"
            };
        }
    }
}
