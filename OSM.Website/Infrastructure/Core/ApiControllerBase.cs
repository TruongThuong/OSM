using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSM.Service;
using OSM.Model.Entities;

using System.Net.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSM.WebCMS.Infrastructure.Core
{
    [Route("api/[controller]")]
    public class ApiControllerBase : Controller
    {
        private IErrorService _errorService;
            public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);

            }
            catch (Exception ex)
            {
                LogError(ex);
                
            }
            return response;
        }

        //thông báo log lỗi
        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error()
                {
                    CreatedDate = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };
                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {

            }
        }
    }
}
