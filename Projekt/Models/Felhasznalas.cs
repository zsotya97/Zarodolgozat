using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Felhasznalas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Gyujtott")]
        public int Gyujtott_id { get; set; }
        [DataType(DataType.Text)]
        [ForeignKey("Betegseg")]
        public int Betegseg_ID{ get; set; }
        [ForeignKey("Elofordulas")]
        public int Elo_Id { get; set; }

        public virtual Elofordulas Elofordulas { get; set; }
        public virtual Betegseg Betegseg { get; set; }
        public virtual Gyujtott Gyujtott { get; set; }
    }
}
