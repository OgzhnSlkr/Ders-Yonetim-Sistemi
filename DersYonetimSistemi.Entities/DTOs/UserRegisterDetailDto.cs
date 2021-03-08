using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DersYonetimSistemi.Entities.DTOs
{
    public class UserRegisterDetailDto : IDto
    {
        [Required,MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        public string Name { get; set; }

        [Required, MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        public string Surname { get; set; }

        [Required, MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz.")]
        [MinLength(5,ErrorMessage = "5 karakterden az olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "5 karakterden az olamaz.")]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "5 karakterden az olamaz.")]
        [MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordAgain { get; set; }
    }
}
