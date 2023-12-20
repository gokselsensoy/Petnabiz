using Business.Abstract;
using Business.BusinessAspect;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class PetManager : IPetService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IPetDal _petDal;


    public PetManager(IPetDal petDal, UserManager<AppUser> userManager)
    {
        _petDal = petDal;
        _userManager = userManager;
    }

    public IDataResult<int> Add(Pet pet)
    {
        _petDal.Add(pet);
        var result = _petDal.Get(p =>
        p.Name == pet.Name &&
        p.Species == pet.Species &&
        p.Breed == pet.Breed &&
        p.Gender == pet.Gender);
        if (result != null)
        {
            return new SuccessDataResult<int>(result.Id /*msg*/);
        }
        return new ErrorDataResult<int>(-1 /*msg*/);
    }

    public IResult Delete(Pet pet)
    {
        var result = BusinessRules.Run(CheckIfPetIdExist(pet.Id));
        if (result != null)
        {
            return result;
        }

        var deletedPet = _petDal.Get(p => p.Id == pet.Id);
        _petDal.Delete(deletedPet);
        return new SuccessResult(/*msg*/);
    }

    public IDataResult<List<Pet>> GetAll()
    {
        return new SuccessDataResult<List<Pet>>(_petDal.GetAll());

    }

    public IDataResult<List<Pet>> GetByUserId(int userId)
    {
        return new SuccessDataResult<List<Pet>>(_petDal.GetAll(p => p.AppUserId == userId));
    }

    public IDataResult<Pet> GetByPetId(int petId)
    {
        return new SuccessDataResult<Pet>(_petDal.Get(p => p.Id == petId));
    }

    public IResult Update(Pet pet)
    {
        var result = BusinessRules.Run(CheckIfPetIdExist(pet.Id));
        if (result != null)
        {
            return result;
        }
        _petDal.Update(pet);
        return new SuccessResult(/*msg*/);
    }

    private IResult CheckIfPetIdExist(int petId)
    {
        var result = _petDal.GetAll(p => p.Id == petId).Any();
        if (!result)
        {
            return new ErrorResult(/*msg*/);
        }
        return new SuccessResult();
    }
}
