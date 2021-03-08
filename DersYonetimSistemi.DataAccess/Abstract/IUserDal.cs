using DersYonetimSistemi.Core.DataAccess;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailDto> GetUsersDetail();
        UserDetailDto GetUserDetail(int userId);
        string GetUserRoleName(int userId);

    }
}
