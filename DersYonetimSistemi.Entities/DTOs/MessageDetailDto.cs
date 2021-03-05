using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.DTOs
{
    public class MessageDetailDto : IDto
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string WriterFullName { get; set; }
        public DateTime MessageAddedDate { get; set; }
        public int LessonId { get; set; }
        public int LessonCrn { get; set; }
        public string LessonName { get; set; }
    }
}
