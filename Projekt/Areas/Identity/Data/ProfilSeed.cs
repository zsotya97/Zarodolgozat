using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Areas.Identity.Data
{
    public static class ProfilSeed
    {
        public static void Admin(this ModelBuilder builder)
        {
            builder.Entity<ProjektUser>().HasData(
               new ProjektUser
               {
                   Id = "c27e9a6d-b867-4e85-a4b7-5701ae225357",
                   Vezetéknév = "Admin",
                   Keresztnév = "Admin",
                   UserName = "Admin@admin.eu",
                   NormalizedUserName = "ADMIN@ADMIN.EU",
                   NormalizedEmail = "ADMIN@ADMIN.EU",
                   Email = "Admin@admin.eu",
                   EmailConfirmed = false,
                   PasswordHash = "AQAAAAEAACcQAAAAELpgJ3SaJS4Ug0+4DI/Md5Gn8cvlEcqTxNL/jv6+zuuq9Iuk4X2SmqUlBJOS2fEAIA==",
                   SecurityStamp = "6UEZLMPV42KN7VZOM3HX2GHPWYEY75YL",
                   ConcurrencyStamp = "3e80628e-9361-45c4-ad82-5fecd720b6af",
                   PhoneNumber = null,
                   PhoneNumberConfirmed = false,
                   TwoFactorEnabled = false,
                   LockoutEnabled = true,
                   LockoutEnd = null,
                   AccessFailedCount = 0
               }
               );
        }
    }
}
