using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.GetReservation
{
    public interface IGetReservation_DA
    {
        ReservationsDTO GetReservation(int id);
    }
}
