using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Core.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        protected BaseEntity()
        {
            IsDeleted = false;
            ModifiedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
