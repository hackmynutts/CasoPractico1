using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReservationByRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReservationByRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Reserve.ReservationByRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reserve.ReservationByRoom
{
    public class ReservationByRoom_BL : IReservationByRoom_BL
    {
        private readonly IReservationByRoom_DA _reservationByRoom_DA;
        public ReservationByRoom_BL()
        {
            _reservationByRoom_DA = new ReservationByRoom_DA();
        }

        public List<ReservationsDTO> GetReservationsByRoom(int idRoom)
        {
            List<ReservationsDTO> reservations = _reservationByRoom_DA.GetReservationsByRoom(idRoom);
            return reservations;
        }
    }
}