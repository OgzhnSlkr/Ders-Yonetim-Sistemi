using DersYonetimSistemi.Core.Utilities.Results;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DersYonetimSistemi.Business.Abstract
{
    public interface IUserService
    {
        IResult Add(UserRegisterDetailDto registerDto);
        IDataResult<UserDetailDto> GetUserDetails(int userId);
        IResult Update(UserDetailDto userDetails);
        IDataResult<User> GetById(int userId);
        IDataResult<List<UserDetailDto>> GetUsersDetails();
        IResult IsUserExists(int userId);
    }
}
