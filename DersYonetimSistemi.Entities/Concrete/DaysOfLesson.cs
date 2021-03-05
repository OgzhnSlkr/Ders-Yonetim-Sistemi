
using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DersYonetimSistemi.Entities.Concrete
{
    public class DaysOfLesson: BaseEntity
    {
        
        
        [Required(ErrorMessage ="Lütfen gün seçiniz.")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "Lütfen gün seçiniz.")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Lütfen gün seçiniz.")]
        public string EndTime { get; set; }
        public ICollection<LessonDay> LessonDays { get; set; }

    }
}
