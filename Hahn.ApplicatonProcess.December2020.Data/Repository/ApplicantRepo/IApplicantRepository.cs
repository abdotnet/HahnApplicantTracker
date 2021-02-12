﻿using Hahn.ApplicatonProcess.December2020.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo
{
    public interface IApplicantRepository : IRepository<ApplicantEntity>
    {
        Task<ApplicantEntity> DeleteAsync(int id);
    }
}