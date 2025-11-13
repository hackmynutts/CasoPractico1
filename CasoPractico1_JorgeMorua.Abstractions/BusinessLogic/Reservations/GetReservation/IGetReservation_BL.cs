using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.GetReservation
{
    public interface IGetReservation_BL
    {
        ReservationsDTO GetReservation(int id);
    }
}
