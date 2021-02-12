using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService
{
    public class ApplicantService : IApplicantService
    {
        public ApplicantService()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> CreateApplicant(Applicant model)
        {
            ApiResponse response = new ApiResponse();
         
            return response;
        }
        public async Task<ApiResponse> GetApplicant(SearchModel model)
        {
            ApiResponse response = new ApiResponse();

            return response;
        }
        public async Task<ApiResponse> UpdateApplicant(Applicant model)
        {
            ApiResponse response = new ApiResponse();

            return response;
        }
        public async Task<ApiResponse> DeleteApplicant(int applicantId)
        {
            ApiResponse response = new ApiResponse();

            return response;
        }
    }
}
