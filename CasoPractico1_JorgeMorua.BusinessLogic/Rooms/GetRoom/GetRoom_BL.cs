using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.GetRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Rooms.GetRoom
{
    public class GetRoom_BL : IGetRoom_BL
    {
        private readonly IGetRoom_DA _getRoom_DA;
        public GetRoom_BL()
        {
            _getRoom_DA = new GetRoom_DA();
        }

        public RoomsDTO GetRoom(string roomId)
        {
            // Implement the logic to get a room by its ID
            RoomsDTO room = _getRoom_DA.GetRoom(roomId);
            return room;
        }

        public RoomsDTO GetRoomID(int roomId)
        {
            // Implement the logic to get a room by its ID
            RoomsDTO room = _getRoom_DA.GetRoomID(roomId);
            return room;
        }
    }
}