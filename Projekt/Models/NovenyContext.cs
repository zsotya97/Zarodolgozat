using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class NovenyContext: DbContext
    {
        public NovenyContext(DbContextOptions<NovenyContext> options) : base(options)
        {

        }
        public DbSet<Novenyek> Novenyek { get; set; }
        public DbSet<Elofordulas> Elofordulas { get; set; }
        public DbSet<Felhasznalas> Felhasznalas { get; set; }
        public DbSet<Betegseg> Betegseg { get; set; }
        public DbSet<Gyujtott> Gyujtott { get; set; }
        

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
