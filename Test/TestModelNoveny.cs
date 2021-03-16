using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models;

namespace Test
{
    public class TestModelNoveny:DbContext
    {
        public DbSet<Elofordulas> elofordulas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite(@"Data Source = ../../../../Projekt/DataBase/Novenyek.db");
        }
    }
}
