using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSM.Service;
using OSM.WebCMS.Models;
using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using OSM.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSM.WebCMS.Controllers
{
    // Test Class
    [Route("api/ProductJSON")]
    public class ProductJSONController : Controller
    {
        #region Initialize

        private IProductService _productService;

        public ProductJSONController(IProductService productCategoryService)

        {
            this._productService = productCategoryService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAll(int page, string keyword, int pageSize = 3)
        {
            var model = _productService.GetAll(keyword);
            int totalRow = model.Count();

            var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
            var responseData = Mapper.Map<IEnumerable<ProductViewModel>>(query);

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            return responseData;
        }
    }
}