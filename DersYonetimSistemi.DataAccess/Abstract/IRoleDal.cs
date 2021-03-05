using DersYonetimSistemi.Core.DataAccess;
using DersYonetimSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
    }
}
