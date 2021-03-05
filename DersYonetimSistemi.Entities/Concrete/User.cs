
using DersYonetimSistemi.Entities.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete
{
    public class User : IdentityUserBaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Surname { get; set; }

        public ICollection<UserLesson> UserLessons { get; set; }
        public ICollection<UserMessage> UserMessages { get; set; }
    }
}
