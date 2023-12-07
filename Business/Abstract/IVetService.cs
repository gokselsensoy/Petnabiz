using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IVetService
{
    IDataResult<List<Vet>> GetAll();
    IDataResult<Vet> GetByVetId(int vetId);
    IDataResult<List<Vet>> GetByClinicId(int clinicId);
    IDataResult<int> Add(Vet vet);
    IResult Update(Vet vet);
    IResult Delete(Vet vet);
}
