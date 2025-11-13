using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Entities
{
    [Table("HABITACIONES")]
    public class RoomsDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("CodigoDeHabitacion")]
        public string codigo { get; set; }
        [Column("Ubicacion")]
        public string location { get; set; }
        [Column("NombreDeHabitacion")]
        public string nombre { get; set; }
        [Column("CantidadDeHuespedesPermitidos")]
        public int cantHuespedes { get; set; }
        [Column("CantidadDeCamas")]
        public int cantCamas { get; set; }
        [Column("CantidadDeBanos")]
        public int cantBanos { get; set; }
        [Column("EncargadoDeLimpieza")]
        public string cleaningLady { get; set; }
        [Column("CostoDeLimpieza")]
        public decimal cleaningFee { get; set; }
        [Column("CostoDeReserva")]
        public decimal roomFee { get; set; }
        [Column("FechaDeRegistro")]
        public DateTime createdAt { get; set; }
        [Column("FechaDeModificacion")]
        public DateTime? updatedAt { get; set; }
        [Column("TipoDeHabitacion")]
        public int roomType { get; set; }      // (1- Junior, 2- Superior, 3- Suite) (En prosa)
        [Column("Estado")]
        public bool estado { get; set; }
    }
}