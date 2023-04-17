using Microsoft.AspNetCore.Identity;
using Ptoject.Enums;
using Ptoject.Models;

namespace Ptoject.Data
{
    public class DefaultUser
    {
        public static List<ApplicationDbUser> IdentityBasicUserList()
        {
            var hasher = new PasswordHasher<ApplicationDbUser>();

            return new List<ApplicationDbUser>()
            {
                new ApplicationDbUser
                {
                    // ادمن لوحه التحكم
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "admin@admin.sa",
                    Email = "admin@admin.sa",
                    NormalizedEmail = "admin@admin.sa",
                    NormalizedUserName = "Admin@Admin.sa",


                },
                new ApplicationDbUser
                {
                    // يوزر لسرفس
                     EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "student@student.sa",
                    Email = "Student@Student.sa",
                    NormalizedEmail = "student@student.sa",
                    NormalizedUserName = "Student@Student.sa",
                },
            };
        }
    }
}
