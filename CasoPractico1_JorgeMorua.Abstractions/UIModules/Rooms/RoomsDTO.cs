using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms
{
    public class RoomsDTO
    {
        public int id{ get; set; }
        [Display (Name = "Room No.")]
        public string codigo { get; set; }
        [Display(Name = "Area")]
        public string location { get; set; }
        [Display (Name = "Nombre")]
        public string nombre { get; set; }
        [Display (Name = "Cant. Huespedes")]
        public int cantHuespedes { get; set; }
        [Display(Name = "Cant. Camas")] 
        public int cantCamas { get; set; }
        [Display(Name = "Cant. Baños")]
        public int cantBanos { get; set; }
        [Display(Name = "Enc. Limpieza")]
        public string cleaningLady { get; set; }
        [Display(Name = "Cost. Limpieza")]
        public decimal cleaningFee { get; set; }
        [Display(Name = "Cost. Cuarto")]
        public decimal roomFee { get; set; }
        [Display(Name = "Tipo")]
        public int roomType { get; set; }      // (1- Junior, 2- Superior, 3- Suite) (En prosa)
        [Display(Name = "Creado En")]
        public DateTime createdAt { get; set; }
        [Display(Name = "Modificado En")]
        public DateTime? updatedAt { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}