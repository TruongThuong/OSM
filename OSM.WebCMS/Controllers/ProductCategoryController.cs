using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSM.Service;
using OSM.WebCMS.Models;
using OSM.WebCMS.Infrastructure.Responses;
using AutoMapper;
using OSM.WebCMS.Infrastructure.Extenssions;
using OSM.Model.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSM.WebCMS.Controllers
{
    [Route("api/productcategory")]
    public class ProductCategoryController : Controller
    {
        #region Initialize
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)

        {
            this._productCategoryService = productCategoryService;
        }
        #endregion Initialize

        [Route("getallparents")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productCategoryService.GetAll();
            int totalRow = model.Count();

            var responseData = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(model);

            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
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
        #region Getall
        [Route("getall")]
        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> GetAll(int page, string keyword, int pageSize = 3)
        {
            var model = _productCategoryService.GetAll(keyword);
            int totalRow = model.Count();

            var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
            var responseData = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(query);

            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
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
            return responseData;
        }
        #endregion Getall

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]ProductCategoryViewModel productCategoryVm)
        {
            var response = new SingleModelResponse<ProductCategoryViewModel>() as ISingleModelResponse<ProductCategoryViewModel>;
            try
            {
                var newProductCategory = Mapper.Map<ProductCategory>(productCategoryVm);
                //newProductCategory.UpdateProductCategory(productCategoryVm);
                _productCategoryService.Add(newProductCategory);
                _productCategoryService.Save();

                //_appsDbContext.Add(newProductCategory);
                //_appsDbContext.SaveChanges();

                var responseData = Mapper.Map<ProductCategoryViewModel>(newProductCategory);
                response.Model = responseData;
                response.Message = productCategoryVm.Name + " đã được thêm thành công";
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
        public IActionResult Update([FromBody]ProductCategoryViewModel productCategoryVm)
        {
            var response = new SingleModelResponse<ProductCategoryViewModel>() as ISingleModelResponse<ProductCategoryViewModel>;
            try
            {
                var dbProductCategory = _productCategoryService.GetById(productCategoryVm.ID);
                dbProductCategory.UpdateProductCategory(productCategoryVm);
                //dbProductCategory = Mapper.Map<ProductCategory>(productCategoryVm);

                _productCategoryService.Update(dbProductCategory);
                _productCategoryService.Save();

                var responseData = Mapper.Map<ProductCategoryViewModel>(dbProductCategory);
                response.Model = responseData;
                response.Message = dbProductCategory.Name + " đã được cập nhật thành công";
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
            var model = _productCategoryService.GetById(id);

            var responseData = Mapper.Map<ProductCategoryViewModel>(model);

            var response = new SingleModelResponse<ProductCategoryViewModel>() as ISingleModelResponse<ProductCategoryViewModel>;
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
            var response = new SingleModelResponse<ProductCategoryViewModel>() as ISingleModelResponse<ProductCategoryViewModel>;
            try
            {
                var oldProductCategory = _productCategoryService.GetById(id);
                _productCategoryService.Delete(id);
                _productCategoryService.Save();

                var responseData = Mapper.Map<ProductCategoryViewModel>(oldProductCategory);
                response.Model = responseData;
                response.Message = oldProductCategory.Name + " Xóa thành công";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        [Route("deletemulti")]
        [HttpDelete]
        public IActionResult DeleteMulti(int[] listIDProductCategory)
        {
            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
            try
            {
                var listTmp = new List<ProductCategoryViewModel>();
                foreach (var item in listIDProductCategory)
                {
                    listTmp.Add(Mapper.Map<ProductCategoryViewModel>(_productCategoryService.GetById(item)));
                    _productCategoryService.Delete(item);
                }
                _productCategoryService.Save();
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
