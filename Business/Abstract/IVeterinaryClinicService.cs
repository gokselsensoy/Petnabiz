using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IVeterinaryClinicService
{
    IDataResult<List<VeterinaryClinic>> GetAll();
    IDataResult<VeterinaryClinic> GetByClinicId(int clinicId);
    IDataResult<List<VeterinaryClinic>> GetByCity(string city);
    IDataResult<int> Add(VeterinaryClinic veterinaryClinic);
    IResult Update(VeterinaryClinic veterinaryClinic);
    IResult Delete(VeterinaryClinic veterinaryClinic);
}
