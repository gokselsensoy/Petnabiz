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

public class PetOwnerManager : IPetOwnerService
{
    private readonly IPetOwnerDal _petOwnerDal;

    public PetOwnerManager(IPetOwnerDal petOwnerDal)
    {
        _petOwnerDal = petOwnerDal;
    }


    public IDataResult<int> Add(PetOwner petOwner)
    {
        _petOwnerDal.Add(petOwner);
        var result = _petOwnerDal.Get(o =>
        o.FirstName == petOwner.FirstName &&
        o.LastName == petOwner.LastName &&
        o.Email == petOwner.Email &&
        o.PhoneNumber == petOwner.PhoneNumber);

        if (result != null)
        {
            return new SuccessDataResult<int>(result.Id /*msg*/);
        }
        return new ErrorDataResult<int>(-1 /*msg*/);
    }

    public IResult Delete(PetOwner petOwner)
    {
        var result = BusinessRules.Run(CheckIfPetOwnerIdExist(petOwner.Id));
        if (result != null)
        {
            return result;
        }

        var deletedPetOwner = _petOwnerDal.Get(o => o.Id == petOwner.Id);
        _petOwnerDal.Delete(deletedPetOwner);
        return new SuccessResult(/*msg*/);
    }

    public IDataResult<List<PetOwner>> GetAll()
    {
        return new SuccessDataResult<List<PetOwner>>(_petOwnerDal.GetAll());
    }

    public IDataResult<List<PetOwner>> GetByClinicId(int clinicId)
    {
        return new SuccessDataResult<List<PetOwner>>(_petOwnerDal.GetAll(o => o.ClinicId == clinicId));
    }

    public IDataResult<PetOwner> GetByOwnerId(int ownerId)
    {
        return new SuccessDataResult<PetOwner>(_petOwnerDal.Get(o => o.Id == ownerId));

    }

    public IResult Update(PetOwner petOwner)
    {
        var result = BusinessRules.Run(CheckIfPetOwnerIdExist(petOwner.Id));
        if (result != null)
        {
            return result;
        }
        _petOwnerDal.Update(petOwner);
        return new SuccessResult(/*msg*/);
    }

    private IResult CheckIfPetOwnerIdExist(int ownerId)
    {
        var result = _petOwnerDal.GetAll(o => o.Id == ownerId).Any();
        if (!result)
        {
            return new ErrorResult(/*msg*/);
        }
        return new SuccessResult();
    }
}
