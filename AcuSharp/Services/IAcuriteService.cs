using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public interface IAcuriteService
    {
        Task<HttpResponseMessage> PostMeasurement(QueryString queryString);
    }
}
