using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete.AssociationEntities
{
    public class LessonDepartment : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
