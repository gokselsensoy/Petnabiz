using Autofac.Features.OwnedInstances;
using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ExaminationManager : IExaminationService
{
    private readonly IExaminationDal _examinationDal;

    public ExaminationManager(IExaminationDal examinationDal)
    {
        _examinationDal = examinationDal;
    }


    public IDataResult<int> Add(Examination examination)
    {
        _examinationDal.Add(examination);
        var result = _examinationDal.Get(e =>
        e.ExaminationDate == examination.ExaminationDate &&
        e.Description == examination.Description &&
        e.VetId == examination.VetId &&
        e.PetId == examination.PetId &&
        e.AppointmentId == examination.AppointmentId &&
        e.VeterinaryClinicId == examination.VeterinaryClinicId &&
        e.AppUserId == examination.AppUserId);
        if (result !=null)
        {
            return new SuccessDataResult<int>(result.Id /*msg*/);
        }
        return new ErrorDataResult<int>(-1 /*msg*/);
    }

    public IResult Delete(Examination examination)
    {
        var result = BusinessRules.Run(CheckIfExaminationIdExist(examination.Id));
        if (result != null)
        {
            return result;
        }

        var deletedExamination = _examinationDal.Get(e => e.Id == examination.Id);
        _examinationDal.Delete(deletedExamination);
        return new SuccessResult(/*msg*/);
    }

    public IDataResult<List<Examination>> GetAll()
    {
        return new SuccessDataResult<List<Examination>>(_examinationDal.GetAll());
    }

    public IDataResult<List<ExaminationDetailDto>> GetExaminationDetails(int userId)
    {
        return new SuccessDataResult<List<ExaminationDetailDto>>(_examinationDal.GetExaminationDetails(userId));
    }
    public IDataResult<List<PetExaminationDetailDto>> GetPetExaminationDetails(int petId)
    {
        return new SuccessDataResult<List<PetExaminationDetailDto>>(_examinationDal.GetPetExaminationDetails(petId));
    }
    public IDataResult<List<PastExaminationDetailDto>> GetPastExaminationDetails(int clinicId)
    {
        return new SuccessDataResult<List<PastExaminationDetailDto>>(_examinationDal.GetPastExaminationDetails(clinicId));
    }

    public IDataResult<Examination> GetByExaminationId(int examinationId)
    {
        return new SuccessDataResult<Examination>(_examinationDal.Get(e => e.Id == examinationId));

    }

    public IDataResult<List<Examination>> GetByUserId(int userId)
    {
        return new SuccessDataResult<List<Examination>>(_examinationDal.GetAll(e => e.AppUserId == userId));

    }

    public IDataResult<List<Examination>> GetByClinicId(int clinicId)
    {
        return new SuccessDataResult<List<Examination>>(_examinationDal.GetAll(e => e.VeterinaryClinicId == clinicId));

    }

    public IDataResult<List<Examination>> GetByPetId(int petId)
    {
        return new SuccessDataResult<List<Examination>>(_examinationDal.GetAll(e => e.PetId == petId));

    }

    public IDataResult<List<Examination>> GetByVetId(int vetId)
    {
        return new SuccessDataResult<List<Examination>>(_examinationDal.GetAll(e => e.VetId == vetId));

    }

    public IResult Update(Examination examination)
    {
        var result = BusinessRules.Run(CheckIfExaminationIdExist(examination.Id));
        if (result != null)
        {
            return result;
        }
        _examinationDal.Update(examination);
        return new SuccessResult(/*msg*/);
    }

    private IResult CheckIfExaminationIdExist(int examinationId)
    {
        var result = _examinationDal.GetAll(e => e.Id == examinationId).Any();
        if (!result)
        {
            return new ErrorResult(/*msg*/);
        }
        return new SuccessResult();
    }
}
