using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IPetOwnerService
{
    IDataResult<List<PetOwner>> GetAll();
    IDataResult<PetOwner> GetByOwnerId(int ownerId);
    IDataResult<List<PetOwner>> GetByClinicId(int clinicId);
    IDataResult<int> Add(PetOwner petOwner);
    IResult Update(PetOwner petOwner);
    IResult Delete(PetOwner petOwner);
}
