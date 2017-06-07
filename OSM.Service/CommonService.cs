using OSM.Common;
using OSM.Data.Infrastructure;
using OSM.Data.Repositories;
using OSM.Model.Entities;
using System.Collections.Generic;

namespace OSM.Service
{
    public interface ICommonService
    {
        Footer GetFooter();

        IEnumerable<Slide> GetSlides();

        SystemConfig GetSystemConfig(string code);
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;

        public CommonService(IFooterRepository footerRepository, ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingle(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }

        public SystemConfig GetSystemConfig(string code)
        {
            return _systemConfigRepository.GetSingle(x => x.Code == code);
        }
    }
}