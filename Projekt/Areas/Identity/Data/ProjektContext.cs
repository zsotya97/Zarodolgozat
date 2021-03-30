using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Areas.Identity.Data;

namespace Projekt.Data
{
    public class ProjektContext : IdentityDbContext<ProjektUser>
    {
        public ProjektContext(DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Adatbázist épít, és az admin methódust fogja előhívni, 
        /// ami az összes adatát feltölti aza datbázisba
        /// </summary>
        /// <param name="builder">Alapértelmezett methódusadat DB céljából</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Admin();
                
              
        }
    }
}
