using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    public class Urls
    {
        public static string GetUrl(HttpContext context)
        {
            var request = context.Request;

            return $"{request.Scheme }://{request.Host.ToUriComponent()}{request.Path}/";
        }
    }
}
