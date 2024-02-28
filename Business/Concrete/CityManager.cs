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
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IDataResult<int> Add(City city)
        {
            _cityDal.Add(city);
            var result = _cityDal.Get(e =>
            e.Name == city.Name);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.Id /*msg*/);
            }
            return new ErrorDataResult<int>(-1 /*msg*/);
        }

        public IResult Delete(City city)
        {
            var result = BusinessRules.Run(CheckIfCityIdExist(city.Id));
            if (result != null)
            {
                return result;
            }

            var deletedCity = _cityDal.Get(e => e.Id == city.Id);
            _cityDal.Delete(deletedCity);
            return new SuccessResult(/*msg*/);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }

        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(e => e.Id == cityId));
        }

        private IResult CheckIfCityIdExist(int cityId)
        {
            var result = _cityDal.GetAll(e => e.Id == cityId).Any();
            if (!result)
            {
                return new ErrorResult(/*msg*/);
            }
            return new SuccessResult();
        }
    }
}
