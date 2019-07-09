using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteApp.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı adı"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(25,ErrorMessage ="Kullanıcı adı 25 karakteri geçemez!")]
        public string Username { get; set; }
        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(75, ErrorMessage = "E-Posta 75 karakteri geçemez!"),
            EmailAddress(ErrorMessage ="{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }
        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "Şifre 25 karakteri geçemez!")]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "Şifre 25 karakteri geçemez!"),
            Compare("Password",ErrorMessage ="{0} ile {1} aynı olmalı.")]
        public string RePassword { get; set; }
    }
}