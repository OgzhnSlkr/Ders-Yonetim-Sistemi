using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Core.Abstract
{
    public interface IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
