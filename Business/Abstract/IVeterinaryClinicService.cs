using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IVeterinaryClinicService
{
    IDataResult<List<VeterinaryClinic>> GetAll();
    IDataResult<ClinicDetailDto> GetClinicDetails(int clinicId);
    IDataResult<VeterinaryClinic> GetByClinicId(int clinicId);
    IDataResult<List<VeterinaryClinic>> GetByCityId(int cityId);
    IDataResult<List<VeterinaryClinic>> GetByDistrictId(int districtId);
    IDataResult<int> Add(VeterinaryClinic veterinaryClinic);
    IResult Update(VeterinaryClinic veterinaryClinic);
    IResult Delete(VeterinaryClinic veterinaryClinic);
}
