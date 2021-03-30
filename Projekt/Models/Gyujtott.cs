using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    //gyujtott tabla adatai
    public class Gyujtott
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        //gyujtott tábla azonosítója: ez a kulcs
        public int ID { get; set; }
        //Kigyűjtött része
        public string Resz { get; set; }
    }
}
