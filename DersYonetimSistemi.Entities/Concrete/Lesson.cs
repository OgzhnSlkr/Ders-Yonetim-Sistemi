using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete
{
    public class Lesson : BaseEntity
    {

        [Required(ErrorMessage = "Ders adı boş bırakılamaz.")]
        public string LessonName { get; set; }

        [Required(ErrorMessage = "Ders CRN'si boş bırakılamaz.")]

        public int LessonCRN { get; set; }

        [Required(ErrorMessage = "Ders kodu boş bırakılamaz.")]

        public string LessonCode { get; set; }

        public string LessonDescription { get; set; }

        [Required(ErrorMessage = "Dersin kredisi boş bırakılamaz.")]
        public double LessonCredit { get; set; }

        [Required(ErrorMessage = "Başlangış Tarihi boş bırakılamaz.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi boş bırakılamaz.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Son Erişim Tarihi boş bırakılamaz.")]
        [DataType(DataType.Date)]
        public DateTime LastAccessDate { get; set; }

        public int TeacherId { get; set; }

        public ICollection<UserLesson> UserLessons { get; set; }
        public ICollection<LessonDay> LessonDays{ get; set; }
        public ICollection<LessonDepartment> LessonDepartments { get; set; }
        public ICollection<LessonMessage> LessonMessages { get; set; }
    }
}
