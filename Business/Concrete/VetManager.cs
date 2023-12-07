using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class VetManager : IVetService
{
    private readonly IVetDal _vetDal;

    public VetManager(IVetDal vetDal)
    {
        _vetDal = vetDal;
    }

    public IDataResult<int> Add(Vet vet)
    {
        _vetDal.Add(vet);
        var result = _vetDal.Get(v =>
        v.FirstName == vet.FirstName &&
        v.LastName == vet.LastName &&
        v.Gender == vet.Gender &&
        v.ClinicId == vet.ClinicId);

        if (result !=null)
        {
            return new SuccessDataResult<int>(result.Id /*msg*/);
        }
        return new ErrorDataResult<int>(-1 /*msg*/);
    }

    public IResult Delete(Vet vet)
    {
        var result = BusinessRules.Run(CheckIfVetIdExist(vet.Id));
        if (result != null)
        {
            return result;
        }

        var deletedVet = _vetDal.Get(v => v.Id == vet.Id);
        _vetDal.Delete(deletedVet);
        return new SuccessResult(/*msg*/);
    }

    public IDataResult<List<Vet>> GetAll()
    {
        return new SuccessDataResult<List<Vet>>(_vetDal.GetAll());

    }

    public IDataResult<Vet> GetByVetId(int vetId)
    {
        return new SuccessDataResult<Vet>(_vetDal.Get(v => v.Id == vetId));
    }

    public IDataResult<List<Vet>> GetByClinicId(int clinicId)
    {
        return new SuccessDataResult<List<Vet>>(_vetDal.GetAll(v => v.ClinicId == clinicId));
    }

    public IResult Update(Vet vet)
    {
        var result = BusinessRules.Run(CheckIfVetIdExist(vet.Id));
        if (result != null)
        {
            return result;
        }
        _vetDal.Update(vet);
        return new SuccessResult(/*msg*/);
    }

    private IResult CheckIfVetIdExist(int vetId)
    {
        var result = _vetDal.GetAll(v => v.Id == vetId).Any();
        if (!result)
        {
            return new ErrorResult(/*msg*/);
        }
        return new SuccessResult();
    }
}
