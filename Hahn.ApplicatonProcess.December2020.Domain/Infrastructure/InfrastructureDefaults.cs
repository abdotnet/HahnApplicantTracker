using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Infrastructure
{
    public class InfrastructureDefaults
    {
        public static string RestCountryUrl { get; private set; } = @"https://restcountries.eu/rest/v2/name/";
    }
}
