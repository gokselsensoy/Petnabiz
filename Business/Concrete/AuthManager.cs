using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    public AuthManager(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IDataResult<int>> Add(AppUserRegisterDto appUserRegisterDto)
    {

        AppUser appUser = new AppUser()
        {
            Name = appUserRegisterDto.Name,
            Surname = appUserRegisterDto.Surname,
            Email = appUserRegisterDto.Email,
            TCID = appUserRegisterDto.TCID
        };
        await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
        if (appUser != null)
        {
            return new SuccessDataResult<int>(appUser.Id /*msg*/);
        }
        return new ErrorDataResult<int>(-1 /*msg*/);
    }
}
