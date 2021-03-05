
using DersYonetimSistemi.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.Abstract
{
    public abstract class IdentityUserBaseEntity : IEntity
    {
        public IdentityUser<int> IdentityBase { get; set; }
        public BaseEntity Base { get; set; }
        protected IdentityUserBaseEntity()
        {
            IdentityBase = new IdentityUser<int>();
            Base = new BaseEntity();
        }

        
       
    }
}
