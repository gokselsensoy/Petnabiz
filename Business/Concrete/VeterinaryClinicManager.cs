using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class VeterinaryClinicManager : IVeterinaryClinicService
{
    private readonly IVeterinaryClinicDal _veterinaryClinicDal;

    public VeterinaryClinicManager(IVeterinaryClinicDal veterinaryClinicDal)
    {
        _veterinaryClinicDal = veterinaryClinicDal;
    }

    public IDataResult<int> Add(VeterinaryClinic veterinaryClinic)
    {
        _veterinaryClinicDal.Add(veterinaryClinic);
        var result = _veterinaryClinicDal.Get(v =>
        v.ClinicName == veterinaryClinic.ClinicName &&
        v.Email == veterinaryClinic.Email &&
        v.PhoneNumber == veterinaryClinic.PhoneNumber &&
        v.Address == veterinaryClinic.Address &&
        v.CityId == veterinaryClinic.CityId &&
        v.DistrictId == veterinaryClinic.DistrictId);

        if (result != null)
        {
            return new SuccessDataResult<int>(result.Id /*Message*/);
        }
        return new ErrorDataResult<int>(-1 /*Message*/);
    }

    public IResult Delete(VeterinaryClinic veterinaryClinic)
    {
        var result = BusinessRules.Run(CheckIfVeterinaryClinicIdExist(veterinaryClinic.Id));
        if (result != null)
        {
            return result;
        }

        var deletedVeterinaryClinic = _veterinaryClinicDal.Get(v => v.Id == veterinaryClinic.Id);
        _veterinaryClinicDal.Delete(deletedVeterinaryClinic);
        return new SuccessResult(/*msg*/);
    }

    public IDataResult<List<VeterinaryClinic>> GetAll()
    {
        return new SuccessDataResult<List<VeterinaryClinic>>(_veterinaryClinicDal.GetAll());
    }
    public IDataResult<ClinicDetailDto> GetClinicDetails(int clinicId)
    {
        return new SuccessDataResult<ClinicDetailDto>(_veterinaryClinicDal.GetClinicDetails(clinicId));
    }

    public IDataResult<VeterinaryClinic> GetByClinicId(int clinicId)
    {
        return new SuccessDataResult<VeterinaryClinic>(_veterinaryClinicDal.Get(v => v.Id == clinicId));
    }

    public IDataResult<List<VeterinaryClinic>> GetByCityId(int cityId)
    {
        return new SuccessDataResult<List<VeterinaryClinic>>(_veterinaryClinicDal.GetAll(v => v.CityId == cityId));
    }
    public IDataResult<List<VeterinaryClinic>> GetByDistrictId(int districtId)
    {
        return new SuccessDataResult<List<VeterinaryClinic>>(_veterinaryClinicDal.GetAll(v => v.DistrictId == districtId));
    }

    public IResult Update(VeterinaryClinic veterinaryClinic)
    {
        var result = BusinessRules.Run(CheckIfVeterinaryClinicIdExist(veterinaryClinic.Id));
        if (result != null)
        {
            return result;
        }
        _veterinaryClinicDal.Update(veterinaryClinic);
        return new SuccessResult(/*msg*/);
    }

    private IResult CheckIfVeterinaryClinicIdExist(int veterinaryClinicId)
    {
        var result = _veterinaryClinicDal.GetAll(v => v.Id == veterinaryClinicId).Any();
        if (!result)
        {
            return new ErrorResult(/*Messages*/);
        }
        return new SuccessResult();
    }
}
