
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Core.Abstract
{
    public abstract class IdentityUserBaseEntity : IdentityUser<int>, IEntity
    {
        protected IdentityUserBaseEntity()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.Now;
        }

        
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
