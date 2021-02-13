using Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository Applicant { get; }
        Task<int> Complete();
    }
}
