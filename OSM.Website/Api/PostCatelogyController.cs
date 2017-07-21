using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using OSM.Service;
using OSM.WebCMS.Infrastructure.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSM.WebCMS.Api
{
    [Route("api/[controller]")]
    public class PostCatelogyController : ApiControllerBase
    {
        public PostCatelogyController(IErrorService errorService) : base(errorService)
        {
        }
    }
}
