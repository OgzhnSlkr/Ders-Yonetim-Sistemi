using DersYonetimSistemi.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework.DbInitializer
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@itu.edu.tr").Result == null)
            {
                User user = new User
                {
                    UserName = "admin",
                    Name = "Oğuzhan",
                    Surname = "Seleker",
                    Email = "admin@itu.edu.tr",
                    AddedDate = DateTime.Now,
                    NormalizedEmail = "admin@itu.edu.tr".ToUpper(),
                    NormalizedUserName = "admin".ToUpper()
                };
                if (userManager.CreateAsync(user,"Admin123").Result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
