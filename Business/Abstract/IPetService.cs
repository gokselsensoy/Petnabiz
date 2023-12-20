using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IPetService
{
    IDataResult<List<Pet>> GetAll();
    IDataResult<Pet> GetByPetId(int petId);
    IDataResult<List<Pet>> GetByUserId(int userId);
    IDataResult<int> Add(Pet pet);
    IResult Update(Pet pet);
    IResult Delete(Pet pet);
}
