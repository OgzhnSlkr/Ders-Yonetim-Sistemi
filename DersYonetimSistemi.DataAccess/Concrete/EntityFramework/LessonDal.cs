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
    }
}
