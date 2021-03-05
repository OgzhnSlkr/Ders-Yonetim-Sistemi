using DersYonetimSistemi.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Abstract
{
    public abstract class IdentityRoleBaseEntity :  IEntity
    {
        public IdentityRole<int> IdentityBase { get; set; }
        public BaseEntity Base { get; set; }
        protected IdentityRoleBaseEntity()
        {
            IdentityBase = new IdentityRole<int>();
            Base = new BaseEntity();
        }

        
    }
}
