using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Reservations.ReservationList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reservations.ReservationsList
{
    public class ReservationList_BL : IReservationList_BL
    {
        private readonly IReservationList_DA _reservationList_DA;
        public ReservationList_BL() 
        {
            _reservationList_DA = new ReservationList_DA();
        }

        public List<ReservationsDTO> GetReservations()
        {
             List<ReservationsDTO> lista = _reservationList_DA.GetReservations();
            return lista;
        }
    }
}