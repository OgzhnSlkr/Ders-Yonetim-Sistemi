using DersYonetimSistemi.Core.Abstract;

namespace DersYonetimSistemi.Entities.DTOs
{
    public class LessonListDetailDto : IDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonCode { get; set; }
        public int LessonCrn { get; set; }
    }
}
