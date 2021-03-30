using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class NovenyContext: DbContext
    {
        /// <summary>
        /// Adatbázis létrehozása migrációal
        /// </summary>
        /// <param name="options">növények adatbázisa Entity framewrok segítségével</param>
        public NovenyContext(DbContextOptions<NovenyContext> options) : base(options)
        {

        }
        public DbSet<Novenyek> Novenyek { get; set; }
        public DbSet<Elofordulas> Elofordulas { get; set; }
        public DbSet<Felhasznalas> Felhasznalas { get; set; }
        public DbSet<Betegseg> Betegseg { get; set; }
        public DbSet<Gyujtott> Gyujtott { get; set; }
        
        /// <summary>
        /// Ez hozza létre az adatokat, seedként
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Betegseg();
            builder.Gyujtott();
            builder.Felhasznalas();
            builder.Elofordulas();
            builder.Novenyek();


        }
    }
}
