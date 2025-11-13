using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReservationByRoom
{
    public interface IReservationByRoom_DA
    {
        List<ReservationsDTO> GetReservationsByRoom(int idRoom);
    }
}
