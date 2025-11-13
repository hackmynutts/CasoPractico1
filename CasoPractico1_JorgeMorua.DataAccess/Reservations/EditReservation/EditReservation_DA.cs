using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reservations.EditReservation
{
    public class EditReservation_DA : IEditReservation_DA
    {
        private Context _context;
        public EditReservation_DA()
        {
            _context = new Context();
        }

        public async Task<int>EditReservation(ReservationsDTO reserve2Edit)
        {
            int linesEdited = 0;
            ReservationsDA reservationBD = _context.Reservations
                            .Where(reserve2find => reserve2find.id == reserve2Edit.id).FirstOrDefault();

            if (reservationBD != null)
            {
                reservationBD.nombrePersona = reserve2Edit.nombrePersona;
                reservationBD.identificacion = reserve2Edit.identificacion;
                reservationBD.cel = reserve2Edit.cel;
                reservationBD.email = reserve2Edit.email;
                reservationBD.fechaNacimiento = reserve2Edit.fechaNacimiento;
                reservationBD.address = reserve2Edit.address;
                reservationBD.monto = reserve2Edit.monto;
                reservationBD.fechaInicioReserva = reserve2Edit.fechaInicioReserva;
                reservationBD.fechaFinReserva = reserve2Edit.fechaFinReserva;
                reservationBD.idRoom = reserve2Edit.idRoom;
                linesEdited = await _context.SaveChangesAsync();
            }
            return linesEdited;
        }
    }
}