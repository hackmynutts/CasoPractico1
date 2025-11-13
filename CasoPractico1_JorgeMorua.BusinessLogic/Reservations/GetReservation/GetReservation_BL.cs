using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Reservations.GetReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reservations.GetReservation
{
    public class GetReservation_BL : IGetReservation_BL
    {
        private IGetReservation_DA _getReservationDA;
        public GetReservation_BL()
        {
            _getReservationDA = new GetReservation_DA();
        }
        public ReservationsDTO GetReservation(int id)
        {
            ReservationsDTO reservation = _getReservationDA.GetReservation(id);
            return reservation;
        }
    }
}