using DersYonetimSistemi.Core.DataAccess.EntityFramework;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.DataAccess.Concrete.EntityFramework.Context;
using DersYonetimSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework
{
    public class RoleDal : EfEntityRepositoryBase<Role,AppDbContext>, IRoleDal 
    {
    }
}
