using DersYonetimSistemi.Core.DataAccess;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<MessageDetailDto> GetMessageDetails(int lessonId);

    }
}
