using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDistrictService
    {
        IDataResult<List<District>> GetAll();
        IDataResult<List<District>> GetByCityId(int cityId);
        IDataResult<District> GetById(int districtId);
        IDataResult<int> Add(District district);
        IResult Delete(District district);
    }
}
