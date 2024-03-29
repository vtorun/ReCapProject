﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Kayıt İşlemi Başarılı";
        public static string NotAdded = "Kayıt İşlemi Başarısız";
        public static string Deleted = "Silme İşlemi Başarılı";
        public static string NotDeleted = "Silme İşlemi Başarısız";
        public static string Updated = "Güncelleme İşlemi Başarılı";
        public static string NotUpdated = "Güncelleme İşlemi Başarısız";
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public const string Listed = "Data başarıyla listelendi";
        public static string CarsListed = "Arabalar Listelendi";
        public static string NotGetAll = "Listeleme Başarısız";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatalı.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated="Token oluşturuldu.";
    }
}
