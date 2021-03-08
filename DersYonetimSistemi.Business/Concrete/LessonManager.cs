using DersYonetimSistemi.Business.Abstract;
using DersYonetimSistemi.Business.Constants;
using DersYonetimSistemi.Core.Utilities.Results;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public IResult AddLesson(Lesson lesson, int userId)
        {
            if (_lessonDal.IsStudent(userId))
            {
                return new ErrorResult(Messages.UnauthorizedAccess);
            }
            var AlreadyInDb = _lessonDal.Get(l => l.LessonCRN == lesson.LessonCRN);
            if (AlreadyInDb != null)
            {
                return new ErrorResult(Messages.LessonAlreadyInDb);
            }

            bool result = _lessonDal.Add(lesson);
            if (result == true)
            {
                return new SuccessResult(Messages.LessonAddSucceed);
            }
            else
            {
                return new ErrorResult(Messages.LessonAddFailed);
            }

        }

        public IResult DeleteLesson(int lessonId, int UserId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<LessonDetailDto> GetLessonById(int lessonId, int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LessonListDetailDto>> GetUsersLessonList(int lessonId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
