using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Web.Contracts.V1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperProfiles()
        {
             CreateMap<Applicant, ApplicantRequest>().ReverseMap();
        }
    }
}
