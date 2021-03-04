using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Core.Abstract
{
    public abstract class IdentityRoleBaseEntity : IdentityRole<int>, IEntity
    {
        protected IdentityRoleBaseEntity()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.Now;
        }

        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
