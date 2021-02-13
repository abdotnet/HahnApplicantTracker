using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Domain.Contracts.V1.Requests;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
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
            CreateMap<Applicant, ApplicantUpdateRequest>().ReverseMap();

        }
    }
}
