using DersYonetimSistemi.Core.DataAccess.EntityFramework;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.DataAccess.Concrete.EntityFramework.Context;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using DersYonetimSistemi.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework
{
    public class LessonDal : EfEntityRepositoryBase<Lesson, AppDbContext>, ILessonDal
    {
        public List<StudentDetailDto> GetAllStudents(int lessonId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = (from s in context.Lessons
                              where s.IsDeleted == false
                             join ss in context.UsersLessons
                             on s.Id equals ss.UserId
                             join sss in context.Users
                             on ss.UserId equals sss.Id
                             select new StudentDetailDto
                             {
                                 UserId = sss.Id,
                                 Name = sss.Name,
                                 Surname = sss.Surname,
                                 Username = sss.UserName,
                                 Email = sss.Email
                             }).ToList();
                var teacher = result.Find(u => u.UserId == GetTeacherByLessonId(lessonId).UserId);
                result.Remove(teacher);
                return result;

            }
        }

        public LessonDetailDto GetLessonDetail(int lessonId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var numberOfStudents = context.UsersLessons.Count(l => l.LessonId == lessonId);
                var result = from l in context.Lessons
                             where l.Id == lessonId
                             where l.IsDeleted == false
                             join u in context.Users
                             on l.TeacherId equals u.Id
                             select new LessonDetailDto
                             {
                                 LessonId = l.Id,
                                 Credit = l.LessonCredit,
                                 Description = l.LessonDescription,
                                 EndDate = l.EndDate,
                                 LastAccessDate = l.LastAccessDate,
                                 LessonCode = l.LessonCode,
                                 LessonCrn = l.LessonCRN,
                                 LessonName = l.LessonName,
                                 NumberOfStudent = numberOfStudents,
                                 StartDate = l.StartDate,
                                 TeacherFullName = u.Name + u.Surname
                             };
                return result.SingleOrDefault();
            }
        }

        public TeacherDetailDto GetTeacherByLessonId(int lessonId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from s in context.Lessons
                             where s.IsDeleted == false
                             join ss in context.Users on s.TeacherId equals ss.Id
                             select new TeacherDetailDto
                             {
                                 LessonId = s.Id,
                                 Name = ss.Name,
                                 Surname = ss.Surname,
                                 UserName = ss.UserName,
                                 UserId = s.TeacherId
                             };
                return result.Single();
            }
        }

        public bool IsUserInLesson(int lessonId, int userId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.UsersLessons.Any(z => z.Id == lessonId && z.UserId == userId);
            }
        }
    }
}
