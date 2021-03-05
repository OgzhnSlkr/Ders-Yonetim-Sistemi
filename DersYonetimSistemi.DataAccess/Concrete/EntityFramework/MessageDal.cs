using DersYonetimSistemi.Core.DataAccess.EntityFramework;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.DataAccess.Concrete.EntityFramework.Context;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework
{
    public class MessageDal : EfEntityRepositoryBase<Message, AppDbContext>, IMessageDal
    {
        public List<MessageDetailDto> GetMessageDetails(int lessonId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from s in context.Lessons
                             where s.IsDeleted == false
                             where s.Id == lessonId
                             join ss in context.LessonMessages
                             on s.Id equals ss.LessonId
                             join sss in context.Messages
                             on ss.MessageId equals sss.Id
                             join ssss in context.UserMessages
                             on sss.Id equals ssss.MessageId
                             join sssss in context.Users
                             on ssss.UserId equals sssss.Id
                             select new MessageDetailDto
                             {
                                 MessageId = sss.Id,
                                 LessonId = lessonId,
                                 UserId = sssss.Id,
                                 WriterFullName = sssss.Name + sssss.Surname,
                                 Content = sss.Content,
                                 Title = sss.Title,
                                 MessageAddedDate = sss.AddedDate,
                                 LessonName = s.LessonName,
                                 LessonCrn = s.LessonCRN
                             };
                return result.ToList();
            }
        }
    }
}
