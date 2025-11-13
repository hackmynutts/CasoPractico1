using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Reservations.EditReservation;
using MiPrimeraSolucion.BusinessLogic.General.DateManagement;
using MyFirstSolution.Abstractions.General.DateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reservations.EditReservation
{
    public class EditReservation_BL : IEditReservation_BL
    {
        private readonly IEditReservation_DA _editReservationDA;
        private Idate _date;
        public EditReservation_BL()
        {
            _editReservationDA = new EditReservation_DA();
            _date = new date();
        }

        public async Task<int> EditReservation(ReservationsDTO reserve2Edit)
        {
            int cantEdited = 0;
            cantEdited = await _editReservationDA.EditReservation(reserve2Edit);
            return cantEdited;
        }
    }
}