using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Entities.DTOs
{
    public class LessonDetailDto : IDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int LessonCrn { get; set; }
        public string LessonCode { get; set; }
        public string Description { get; set; }
        public double Credit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string TeacherFullName { get; set; }
        public int NumberOfStudent { get; set; }

    }
}
