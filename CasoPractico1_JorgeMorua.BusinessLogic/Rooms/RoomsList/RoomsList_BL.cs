using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.RoomsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Rooms.RoomsList
{
    public class RoomsList_BL : IRoomsList_BL
    {
        private readonly IRoomsList_DA _roomsListDA;
        public RoomsList_BL()
        {
            _roomsListDA = new RoomsList_DA();
        }

        public List<RoomsDTO> GetRooms()
        {
            List<RoomsDTO> rooms = _roomsListDA.GetRooms();
            return rooms;
        }

        public List<RoomsDTO> GetRoomsActivos()
        {
            List<RoomsDTO> rooms = _roomsListDA.GetRoomsActivos();
            return rooms;
        }
    }
}