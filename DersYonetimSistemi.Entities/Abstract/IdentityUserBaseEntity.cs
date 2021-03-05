
using DersYonetimSistemi.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.Abstract
{
    public abstract class IdentityUserBaseEntity : IdentityUser<int>, IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        protected IdentityUserBaseEntity()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.Now;
        }


    }
}
