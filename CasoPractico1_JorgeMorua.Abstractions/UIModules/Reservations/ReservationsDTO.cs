using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations
{
    public class ReservationsDTO
    {
        public int id { get; set; }
        [Display(Name = "Nombre de la Persona")]
        public string nombrePersona { get; set; }
        [Display(Name = "Identificación")]
        public string identificacion { get; set; }
        [Display(Name = "Teléfono")]
        public string cel { get; set; }
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }
        [Display(Name = "DOB")]
        public DateTime fechaNacimiento { get; set; }
        [Display(Name = "Dirección")]
        public string address { get; set; }
        [Display(Name = "Monto Total")]
        public decimal monto { get; set; }
        [Display(Name = "Fecha Inicio Reserva")]
        public DateTime fechaInicioReserva { get; set; }
        [Display(Name = "Fecha Fin Reserva")]
        public DateTime fechaFinReserva { get; set; }
        [Display(Name = "Fecha De Registro")]
        public DateTime createdAt { get; set; }
        [Display(Name = "ID Habitación")]
        public int idRoom { get; set; }

    }
}