using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService
{
    public interface IApplicantService
    {
        Task<ApiResponse> CreateApplicant(Applicant model);
        Task<ApiResponse> GetApplicant(SearchModel model);
        Task<ApiResponse> UpdateApplicant(Applicant model);
        Task<ApiResponse> DeleteApplicant(int applicantId);
    }
}
