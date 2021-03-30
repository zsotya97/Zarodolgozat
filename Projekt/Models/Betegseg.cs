using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    //betegseg tábla adatai
    public class Betegseg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Betegseg tábla azonosítója: ez a kulcs
        public int ID { get; set; }
        ///EZ a típusa a betegségnek
        public string Tipus { get; set; }
    }
}
