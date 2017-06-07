using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSM.WebCMS.Models;
using AutoMapper;
using OSM.WebCMS.Infrastructure.Responses;
using OSM.WebCMS.Infrastructure.Extenssions;
using OSM.Service;
using OSM.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSM.WebCMS.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        #region Initialize

        private IProductService _productService;

        public ProductController(IProductService productCategoryService)

        {
            this._productService = productCategoryService;
        }

        #endregion Initialize

        [Route("getallparents")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            int totalRow = model.Count();

            var responseData = Mapper.Map<IEnumerable<ProductViewModel>>(model);

            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;
            try
            {
                response.Model = responseData;

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.ToHttpResponse();
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll(int page, string keyword, int pageSize = 3)
        {
            var model = _productService.GetAll(keyword);
            int totalRow = model.Count();

            var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
            var responseData = Mapper.Map<IEnumerable<ProductViewModel>>(query);

            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;
            try
            {
                response.TotalRows = totalRow;
                //rows per page
                response.PageSize = query.Count();
                response.PageNumber = page;
                response.TotalPages = (int)Math.Ceiling((double)totalRow / pageSize);
                response.Model = responseData;

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.ToHttpResponse();
        }

        [Route("createproduct")]
        [HttpPost]
        public IActionResult Create([FromBody]ProductViewModel productVm)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;
            try
            {
                var newProduct = Mapper.Map<Product>(productVm);
                _productService.Add(newProduct);
                _productService.Save();

                //_appsDbContext.Add(newProductCategory);
                //_appsDbContext.SaveChanges();

                var responseData = Mapper.Map<ProductViewModel>(newProduct);
                response.Model = responseData;
                response.Message = productVm.Name + " đã được thêm thành công";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody]ProductViewModel productVm)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;
            try
            {
                var dbProduct = _productService.GetById(productVm.ID);
                dbProduct.UpdateProduct(productVm);

                _productService.Update(dbProduct);
                _productService.Save();

                var responseData = Mapper.Map<ProductViewModel>(dbProduct);
                response.Model = responseData;
                response.Message = dbProduct.Name + " đã được cập nhật thành công";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);

            var responseData = Mapper.Map<ProductViewModel>(model);

            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;
            try
            {
                response.Model = responseData;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.ToHttpResponse();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;
            try
            {
                var oldProduct = _productService.GetById(id);
                _productService.Delete(id);
                _productService.Save();

                var responseData = Mapper.Map<ProductViewModel>(oldProduct);
                response.Model = responseData;
                response.Message = oldProduct.Name + " Xóa thành công";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        [Route("deletemultiple")]
        [HttpDelete]
        public IActionResult DeleteMulti(int[] listIDProduct)
        {
            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;
            try
            {
                var listTmp = new List<ProductViewModel>();
                foreach (var item in listIDProduct)
                {
                    listTmp.Add(Mapper.Map<ProductViewModel>(_productService.GetById(item)));
                    _productService.Delete(item);
                }
                _productService.Save();
                response.Model = listTmp;
                response.Message = " Xóa thành công";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }
    }
}
