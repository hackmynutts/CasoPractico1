using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reservations.ReservationList
{
    public class ReservationList_DA : IReservationList_DA
    {
        private Context _context;
        public ReservationList_DA() 
        {
            _context = new Context();
        }

        public List<ReservationsDTO> GetReservations()
        { 
            List<ReservationsDTO> reservationList = (from reservations
                                                    in _context.Reservations
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
                                                    }).ToList();
            return reservationList;
        }
    }
}