using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReserveList;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReserveList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Reserve.ReserveList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reserve.ReserveList
{
    public class ReserveList_BL : IReserveList_BL
    {
        private readonly IReserveList_DA _reserveListDA;
        public ReserveList_BL()
        {
            _reserveListDA = new ReserveList_DA();
        }

        public List<RoomsDTO> GetReserveList()
        {
            List<RoomsDTO> reserveList = _reserveListDA.GetReserveList();
            return reserveList;
        }
    }
}