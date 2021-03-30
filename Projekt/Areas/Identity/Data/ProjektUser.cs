using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projekt.Areas.Identity.Data
{
    // Identity bővült kettő adattal
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
