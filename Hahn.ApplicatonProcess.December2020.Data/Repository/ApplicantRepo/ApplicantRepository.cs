using Hahn.ApplicatonProcess.December2020.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo
{
    public class ApplicantRepository : IApplicantRepository
    {
        public Task<ApplicantEntity> AddAsync(ApplicantEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantEntity> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicantEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantEntity> UpdateAsync(ApplicantEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
