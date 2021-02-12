using Hahn.ApplicatonProcess.December2020.Domain.Entities;
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

        public Task<Applicant> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
