using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    //felhasznalas tabla adatai
    public class Felhasznalas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //felhasznalas tábla azonosítója: ez a kulcs
        public int ID { get; set; }
        [ForeignKey("Gyujtott")]
        //Gyujtott tábla azonosítója: idegenkulcs
        public int Gyujtott_id { get; set; }
        [DataType(DataType.Text)]
        [ForeignKey("Betegseg")]
        //Betegseg tábla azonosítója: idegenkulcs
        public int Betegseg_ID{ get; set; }
        [ForeignKey("Elofordulas")]
        //Elofordulas tábla azonosítója: idegenkulcs
        public int Elo_Id { get; set; }

        //idegenkulcsok
        public virtual Elofordulas Elofordulas { get; set; }
        public virtual Betegseg Betegseg { get; set; }
        public virtual Gyujtott Gyujtott { get; set; }
    }
}
