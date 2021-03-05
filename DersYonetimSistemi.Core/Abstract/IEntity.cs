
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Core.Abstract
{
    public interface IEntity 
    {
        bool IsDeleted { get; set; }
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime DeletedDate { get; set; }
    }
}
