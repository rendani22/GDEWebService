using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GDEWebserviceCore.Models;
using AssessmentStructureWS;

namespace GDEWebserviceCore.Controllers
{
    public class HomeController : AssessmentStructureWSSoap
    {
        ProductResponse productResponse = new ProductResponse();

        public Task<ProductResponse> ProductAsync(ProductResponse productResponse)
        {

            return null;
        }
        public Task<string> PingAsync() {

            return null;
        }

        public Task<string> MarkSchemeStructureAsync()
        {

            return null;
        }
        public Task<string> MarkSchemeAnswerAsync()
        {

            return null;
        }
        public Task<string> LayoutAsync()
        {

            return null;
        }


    }
}
