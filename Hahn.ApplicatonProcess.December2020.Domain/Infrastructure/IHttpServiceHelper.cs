using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Infrastructure
{
    public interface IHttpServiceHelper
    {
        Task<String> GetHttpClient(string url);
        Task<String> PostHttpClient(String url, String jsonObject);
    }
}
