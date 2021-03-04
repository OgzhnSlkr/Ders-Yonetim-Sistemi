using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete.AssociationEntities
{
    public class UserLesson : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }


    }
}
