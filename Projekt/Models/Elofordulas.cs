using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    //elofordulás tábla adatai
    public class Elofordulas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Elofordulas tábla azonosítója: ez a kulcs
        public int ID { get; set; }
        //Ez a hónap
        public string Honap  { get; set; }
        
    }
}
