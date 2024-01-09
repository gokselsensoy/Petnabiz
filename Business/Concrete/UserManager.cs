using Business.Abstract;
using Business.Utilities.JWT;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        private ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<List<OperationClaim>> GetClaims(AppUser user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(user.Id));
            if (rulesResult != null)
            {
                return new ErrorDataResult<List<OperationClaim>>(rulesResult.Message);
            }

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<AccessToken> CreateAccessToken(AppUser user)
        {
            var claims = GetClaims(user);
            var token = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(token);
        }

        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(u => u.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
