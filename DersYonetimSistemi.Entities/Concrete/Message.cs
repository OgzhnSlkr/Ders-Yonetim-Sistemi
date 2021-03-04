using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete
{
    public class Message : BaseEntity
    {
        [Required(ErrorMessage = "Mesajınız başlığı olmalıdır."), MaxLength(70, ErrorMessage = "Başlık 70 karakterden fazla olamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mesajınızın içeriği olmalıdır."), MaxLength(500, ErrorMessage = "içerik 500 karakterden fazla olamaz")]
        public string Content { get; set; }

        public ICollection<UserMessage> UserMessages { get; set; }
        public ICollection<LessonMessage> LessonMessages { get; set; }
    }
}
