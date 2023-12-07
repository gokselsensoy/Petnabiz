using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IExaminationService
{
    IDataResult<List<Examination>> GetAll();
    IDataResult<Examination> GetByExaminationId(int examinationId);
    IDataResult<List<Examination>> GetByPetId(int petId);
    IDataResult<List<Examination>> GetByOwnerId(int ownerId);
    IDataResult<List<Examination>> GetByVetId(int vetId);
    IDataResult<int> Add(Examination examination);
    IResult Update(Examination examination);
    IResult Delete(Examination examination);
}
