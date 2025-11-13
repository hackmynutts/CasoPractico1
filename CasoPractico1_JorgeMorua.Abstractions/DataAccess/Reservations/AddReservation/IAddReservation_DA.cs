using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.AddReservation
{
    public interface IAddReservation_DA
    {
        Task<int> AddReservation(ReservationsDTO reserve2Add);
    }
}
