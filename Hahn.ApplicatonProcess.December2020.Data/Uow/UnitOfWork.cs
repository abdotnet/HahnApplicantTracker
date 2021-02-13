using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public  IApplicantRepository Applicant { get; private set; }
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Applicant = new ApplicantRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
