using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.Concrete.AssociationEntities
{
    public class UserMessage : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}
