using DersYonetimSistemi.Core.DataAccess.EntityFramework;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.DataAccess.Concrete.EntityFramework.Context;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework
{
    public class UserDal : EfEntityRepositoryBase<User, AppDbContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetail()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from s in context.Users 
                             where s.IsDeleted == false
                             join ss in context.UserRoles
                             on s.Id equals ss.UserId
                             join sss in context.Roles
                             on ss.RoleId equals sss.Id
                             select new UserDetailDto
                             {
                                 UserId = s.Id,
                                 RoleId = sss.Id,
                                 Name = s.Name,
                                 Surname = s.Surname,
                                 Username = s.UserName,
                                 Email = s.Email,
                                 RoleName = sss.Name
                             };
                return result.ToList();
            }
        }
    }
}
