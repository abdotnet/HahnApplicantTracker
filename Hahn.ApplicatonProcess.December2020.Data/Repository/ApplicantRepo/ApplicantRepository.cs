using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public DataContext DbContext
        {
            get
            {
                return _dataContext as DataContext;
            }
        }
        public ApplicantRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<ApiResponse> GetPagedApplicants(SearchModel model)
        {
            ApiResponse response = new ApiResponse();

            await Task.Run(() => { });

            return response;

        }
    }
}
