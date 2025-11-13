using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.EditRoom;
using MiPrimeraSolucion.BusinessLogic.General.DateManagement;
using MyFirstSolution.Abstractions.General.DateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Rooms.EditRoom
{
    public class EditRoom_BL : IEditRoom_BL
    {
        private IEditRoom_DA _editRoomDA;
        private Idate _date;
        public EditRoom_BL()
        {
            _editRoomDA = new EditRoom_DA();
            _date = new date();
        }

        public async Task<int> EditRoom(RoomsDTO roomEdit)
        {
            int CantEdit = 0;
            roomEdit.updatedAt = _date.GetDate();
            CantEdit = await _editRoomDA.EditRoom(roomEdit);
            return CantEdit;
        }
    }
}