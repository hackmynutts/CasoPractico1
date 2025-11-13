using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Entities
{
    [Table("RESERVACIONES")]
    public class ReservationsDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("NombreDeLaPersona")]
        public string nombrePersona { get; set; }
        public string identificacion { get; set; }
        [Column("Telefono")]
        public string cel { get; set; }
        [Column("Correo")]
        public string email { get; set; }
        [Column("FechaNacimiento")]
        public DateTime fechaNacimiento { get; set; }
        [Column("Direccion")]
        public string address { get; set; }
        [Column("MontoTotal")]
        public decimal monto { get; set; }
        public DateTime fechaInicioReserva { get; set; }
        public DateTime fechaFinReserva { get; set; }
        [Column("FechaDeRegistro")]
        public DateTime createdAt { get; set; }
        [Column("IdHabitacion")]
        public int idRoom { get; set; }
    }
}