using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<ApiResponse> GetPagedApplicants(SearchModel model);

    }
}
