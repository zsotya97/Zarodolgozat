using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    //Novenyek adattáblája
    public class Novenyek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Novenyek azonosítoja: ez  a kulcs
        public int ID { get; set; }
        [DataType(DataType.Text)]
        //Latin neve
        public string Latin { get; set; }
        [DataType(DataType.Text)]
        //Magyar neve
        public string Magyar { get; set; }
        [DataType(DataType.Text)]
        //Kép címe
        public string Kep { get; set; }
        [DataType(DataType.Text)]
        //Növény leírása
        public string Informacio { get; set; }
        [ForeignKey("Felhasznalas")]
        //Felhasznalo tábla azonosítója: idegenkulcs
        public int Felh_Id { get; set; }
        //idegenkulcs
        public virtual Felhasznalas Felhasznalas{ get; set; }
    }
}
