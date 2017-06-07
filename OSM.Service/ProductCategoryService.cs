using OSM.Data.Infrastructure;
using OSM.Data.Repositories;
using OSM.Model.Entities;
using System.Collections.Generic;

namespace OSM.Service
{
    public interface IProductCategoryService
    {
        void Add(ProductCategory ProductCategory);

        void Update(ProductCategory ProductCategory);

        void Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _ProductCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository ProductCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._ProductCategoryRepository = ProductCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Add(ProductCategory);
        }

        public void Delete(int id)
        {
            _ProductCategoryRepository.GetSingle(id).isDeleted = true;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategoryRepository.GetMulti(x => x.isDeleted == false);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ProductCategoryRepository.GetMulti(x =>x.isDeleted ==false && (x.Name.Contains(keyword) || x.Description.Contains(keyword)));
            else
                return _ProductCategoryRepository.GetMulti(x => x.isDeleted == false);
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _ProductCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _ProductCategoryRepository.GetSingle(id);
        }

        public void Save()
        {
            _ProductCategoryRepository.Commit();
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Update(ProductCategory);
        }
    }
}