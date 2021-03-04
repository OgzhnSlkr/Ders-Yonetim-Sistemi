using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete.AssociationEntities
{
    public class LessonMessage : BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}
