using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reservations.GetReservation
{
    public class GetReservation_DA : IGetReservation_DA
    {
        private Context _context;
        public GetReservation_DA()
        {
            _context = new Context();
        }

        public ReservationsDTO GetReservation(int id)
        {
            ReservationsDTO reservation = (from reservations
                                           in _context.Reservations
                                             where reservations.id == id
                                           select new ReservationsDTO
                                                     {
                                                         id = reservations.id,
                                                         nombrePersona = reservations.nombrePersona,
                                                         identificacion = reservations.identificacion,
                                                         cel = reservations.cel,
                                                         email = reservations.email,
                                                         fechaNacimiento = reservations.fechaNacimiento,
                                                         address = reservations.address,
                                                         monto = reservations.monto,
                                                         fechaInicioReserva = reservations.fechaInicioReserva,
                                                         fechaFinReserva = reservations.fechaFinReserva,
                                                         createdAt = reservations.createdAt,
                                                         idRoom = reservations.idRoom
                                                     }).FirstOrDefault();
            return reservation;
        }
    }
}