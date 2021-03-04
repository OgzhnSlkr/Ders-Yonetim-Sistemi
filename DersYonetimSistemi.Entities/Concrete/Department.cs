using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete
{
    public class Department : BaseEntity
    {
        [Required(ErrorMessage = "Fakülte Adı boş bırakılamaz.")]
        public string DepartmentName { get; set; }

        public ICollection<LessonDepartment> LessonDepartments{ get; set; }
    }
}
