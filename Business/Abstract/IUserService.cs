using Business.Utilities.JWT;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(AppUser user);
        IDataResult<AccessToken> CreateAccessToken(AppUser user);
        IDataResult<List<AppUser>> GetByClinicId(int clinicId);
        IDataResult<AppUser> GetByUserId(int userId);
    }
}
