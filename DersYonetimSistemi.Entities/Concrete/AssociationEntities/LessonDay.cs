using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete.AssociationEntities
{
    public class LessonDay : BaseEntity
    {
        public int DayId { get; set; }
        public DaysOfLesson daysOfLesson { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
