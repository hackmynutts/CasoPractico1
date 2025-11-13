using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.AddRoom;
using MiPrimeraSolucion.BusinessLogic.General.DateManagement;
using MyFirstSolution.Abstractions.General.DateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Rooms.AddRoom
{
    public class AddRoom_BL : IAddRoom_BL
    {
        private IAddRoom_DA _addRoomDA;
        private Idate _date;
        public AddRoom_BL()
        {
            _addRoomDA = new AddRoom_DA();
            _date = new date();
        }

        public async Task<int> AddRoom( RoomsDTO roomReservation)
        {
            roomReservation.createdAt = _date.GetDate();
            roomReservation.estado = true;
            int insertedRoom = await _addRoomDA.AddRoom(roomReservation);
            return insertedRoom;
        }
    }
}