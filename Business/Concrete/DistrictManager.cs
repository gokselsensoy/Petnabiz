using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public IDataResult<int> Add(District district)
        {
            _districtDal.Add(district);
            var result = _districtDal.Get(e =>
            e.CityId == district.CityId &&
            e.Name == district.Name);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.Id /*msg*/);
            }
            return new ErrorDataResult<int>(-1 /*msg*/);
        }

        public IResult Delete(District district)
        {
            var result = BusinessRules.Run(CheckIfDistrictIdExist(district.Id));
            if (result != null)
            {
                return result;
            }

            var deletedDistrict = _districtDal.Get(e => e.Id == district.Id);
            _districtDal.Delete(deletedDistrict);
            return new SuccessResult(/*msg*/);
        }

        public IDataResult<List<District>> GetAll()
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetAll());
        }

        public IDataResult<List<District>> GetByCityId(int cityId)
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetAll(e => e.CityId == cityId));
        }

        public IDataResult<District> GetById(int districtId)
        {
            return new SuccessDataResult<District>(_districtDal.Get(e => e.Id == districtId));
        }

        private IResult CheckIfDistrictIdExist(int districtId)
        {
            var result = _districtDal.GetAll(e => e.Id == districtId).Any();
            if (!result)
            {
                return new ErrorResult(/*msg*/);
            }
            return new SuccessResult();
        }
    }
}
