using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Novenyek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DataType(DataType.Text)]
        public string Latin { get; set; }
        [DataType(DataType.Text)]
        public string Magyar { get; set; }
        [DataType(DataType.Text)]
        public string Kep { get; set; }
        [DataType(DataType.Text)]
        public string Informacio { get; set; }
        [ForeignKey("Felhasznalas")]
        public int Felh_Id { get; set; }
        public virtual Felhasznalas Felhasznalas{ get; set; }
    }
}
