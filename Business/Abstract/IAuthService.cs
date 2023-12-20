using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<int>> Add(AppUserRegisterDto appUserRegisterDto);
    }
}
