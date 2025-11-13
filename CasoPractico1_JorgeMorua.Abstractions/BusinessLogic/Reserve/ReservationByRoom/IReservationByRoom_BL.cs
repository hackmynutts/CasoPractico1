using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReservationByRoom
{
    public interface IReservationByRoom_BL
    {
        List<ReservationsDTO> GetReservationsByRoom(int idRoom);
    }
}
