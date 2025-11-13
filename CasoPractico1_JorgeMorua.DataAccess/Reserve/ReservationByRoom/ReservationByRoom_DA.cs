using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReservationByRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reserve.ReservationByRoom
{
    public class ReservationByRoom_DA : IReservationByRoom_DA
    {
        private Context _context;
        public ReservationByRoom_DA()
        {
            _context = new Context();
        }

        public List<ReservationsDTO> GetReservationsByRoom(int idRoom)
        {
            List<ReservationsDTO> reservationsR = (from reservations
                                            in _context.Reservations
                                            where reservations.idRoom == idRoom
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
            return reservationsR;
        }
    }
}