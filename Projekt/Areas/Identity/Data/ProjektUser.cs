using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projekt.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ProjektUser class
    public class ProjektUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string Vezetéknév { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Keresztnév { get; set; }

    }
}
