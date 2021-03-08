using DersYonetimSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Business.Constants
{
    public static class Messages
    {
        public static string UserAlreadyExists = "Böyle biri sistemde kayıtlı";
        public static string RegisterSucceeded = "Kayıtlı Başarılı";
        public static string RegisterFailed = "Kayıtlı Başarısız";
        public static string UserNotFound = "Böyle biri yok";
        public static string RegisterAndRoleAddSuccedd = "Başarılı bir şekilde kayıt olundu ve varsayılan olarak öğrenci rolu eklendi.";

        public static string GetUserDetailsFailed = "Kullanıcı bilgileri alınamadı";
        public static string AllUpdatesSucced = "kullanıcının eski rolü kaldırıldı yenisi eklendi ve bilgileri güncellendi.";
        public static string OnlyRoleUpdated ="Kullanıcının sadece rolü güncellendi bilgileri güncellenemedi";
        public static string OnlyRoleRemoved = "Kullanıcı sadece rolden çıkartıldı. Yeni rol eklenemedi ve bilgileri güncellenemedi.";
        public static string AllUpdatesFailed = "Güncelleme başarısız.";
        public static string UnauthorizedAccess = "Yetkisiz Erişim!";
        public static string LessonAlreadyInDb = "Sistemde aynı CRN kodlu ders bulundu.";
        public static string LessonAddSucceed = "Ders ekleme başarılı";
        public static string LessonAddFailed = "Ders ekleme başarısız";
    }
}
