using DersYonetimSistemi.Core.DataAccess;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Abstract
{
    public interface ILessonDal : IEntityRepository<Lesson>
    {
        TeacherDetailDto GetTeacherByLessonId(int lessonId);
        List<StudentDetailDto> GetAllStudents(int lessonId);
    }
}
