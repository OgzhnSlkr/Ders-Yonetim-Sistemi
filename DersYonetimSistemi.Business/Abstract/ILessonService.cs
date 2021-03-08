using DersYonetimSistemi.Core.Utilities.Results;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Business.Abstract
{
    public interface ILessonService
    {
        IDataResult<LessonDetailDto> GetLessonById(int lessonId, int userId);
        IDataResult<List<LessonListDetailDto>> GetUsersLessonList(int lessonId, int userId);
        IResult AddLesson(Lesson lesson, int userId);
        IResult DeleteLesson(int lessonId, int UserId);
    }
}
