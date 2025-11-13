using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Rooms.EditRoom
{
    public class EditRoom_DA : IEditRoom_DA
    {
        private Context _context;
        public EditRoom_DA()
        {
            _context = new Context();
        }

        public async Task<int> EditRoom(RoomsDTO roomEdit)
        {
            int linesEdited = 0;
            RoomsDA roomBD = _context.Rooms
                            .Where(room2find => room2find.codigo == roomEdit.codigo).FirstOrDefault();
            if (roomBD != null)
            {
                roomBD.codigo = roomEdit.codigo;
                roomBD.location = roomEdit.location;
                roomBD.nombre = roomEdit.nombre;
                roomBD.cantHuespedes = roomEdit.cantHuespedes;
                roomBD.cantCamas = roomEdit.cantCamas;
                roomBD.cantBanos = roomEdit.cantBanos;
                roomBD.cleaningLady = roomEdit.cleaningLady;
                roomBD.cleaningFee = roomEdit.cleaningFee;
                roomBD.roomFee = roomEdit.roomFee;
                roomBD.roomType = roomEdit.roomType;
                roomBD.updatedAt = roomEdit.updatedAt;
                roomBD.estado = roomEdit.estado;
                linesEdited = await _context.SaveChangesAsync();
            }
            return linesEdited;
        }
    }
}