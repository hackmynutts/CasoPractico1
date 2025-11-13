using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReserveList
{
    public interface IReserveList_BL
    {
        List<RoomsDTO> GetReserveList();
    }
}
