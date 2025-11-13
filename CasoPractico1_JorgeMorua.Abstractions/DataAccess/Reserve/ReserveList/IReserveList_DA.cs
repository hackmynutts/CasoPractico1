using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReserveList
{
    public interface IReserveList_DA
    {
        List<RoomsDTO> GetReserveList();
    }
}
