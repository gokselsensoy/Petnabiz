using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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
    IDataResult<List<ExaminationDetailDto>> GetExaminationDetails(int userId);
    IDataResult<List<PetExaminationDetailDto>> GetPetExaminationDetails(int petId);
    IDataResult<List<PastExaminationDetailDto>> GetPastExaminationDetails(int clinicId);
    IDataResult<List<Examination>> GetByPetId(int petId);
    IDataResult<List<Examination>> GetByUserId(int userId);
    IDataResult<List<Examination>> GetByVetId(int vetId);
    IDataResult<List<Examination>> GetByClinicId(int clinicId);
    IDataResult<int> Add(Examination examination);
    IResult Update(Examination examination);
    IResult Delete(Examination examination);
}
