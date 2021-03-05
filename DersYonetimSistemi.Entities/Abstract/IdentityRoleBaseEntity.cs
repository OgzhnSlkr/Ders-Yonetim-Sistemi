using DersYonetimSistemi.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Abstract
{
    public abstract class IdentityRoleBaseEntity : IdentityRole<int>, IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        protected IdentityRoleBaseEntity()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.Now;
        }

        
    }
}
