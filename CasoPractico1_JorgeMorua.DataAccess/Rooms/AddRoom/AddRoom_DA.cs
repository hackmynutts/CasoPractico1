using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Rooms.AddRoom
{
    public class AddRoom_DA : IAddRoom_DA
    {
        private Context _context;
        public AddRoom_DA()
        {
            _context = new Context();
        }

        public async Task<int> AddRoom(RoomsDTO newRoom)
        {
            try
            {
                RoomsDA newRoomDA = Convert2DA(newRoom);

                _context.Rooms.Add(newRoomDA);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar: " + ex.GetBaseException().Message, ex);
            }
        }

        private RoomsDA Convert2DA (RoomsDTO rooms)
        {
            return new RoomsDA
            {
                id = rooms.id,
                codigo = rooms.codigo,
                location = rooms.location,
                nombre = rooms.nombre,
                cantHuespedes = rooms.cantHuespedes,
                cantCamas = rooms.cantCamas,
                cantBanos = rooms.cantBanos,
                cleaningLady = rooms.cleaningLady,
                cleaningFee = rooms.cleaningFee,
                roomFee = rooms.roomFee,
                roomType = rooms.roomType,
                createdAt = rooms.createdAt,
                updatedAt = rooms.updatedAt,
                estado = rooms.estado
            };
        }
    }
}