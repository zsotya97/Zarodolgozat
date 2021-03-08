using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    
    sealed public class Osszesitett
    {
        [BindProperty]
        public int ID { get; set; }
        public string Magyar { get; set; }
        public string Latin { get; set; }
        public string Honap { get; set; }
        public string Resz { get; set; }
        public string Tipus { get; set; }
        public string Kep { get; set; }
        public string Leiras { get; set; }
        public static IEnumerable<Osszesitett> modell { get; set; }
        public static IEnumerable<Betegseg> betegseg { get; set; }
        public static IEnumerable<Elofordulas> elofordulas { get; set; }
        public static IEnumerable<Gyujtott>gyujtott  { get; set; }
    }
}
