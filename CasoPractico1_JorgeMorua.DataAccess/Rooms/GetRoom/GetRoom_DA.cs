using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Rooms.GetRoom
{
    public class GetRoom_DA : IGetRoom_DA
    {
        private Context _context;
        public GetRoom_DA()
        {
            _context = new Context();
        }

        // Implement data access methods to retrieve room information from the database
        public RoomsDTO GetRoom(string roomCodigo)
        {
            RoomsDTO room = (from rooms
                             in _context.Rooms
                             where rooms.codigo == roomCodigo
                             select new RoomsDTO
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
                               }).FirstOrDefault();
            return room;
        }

        public RoomsDTO GetRoomID(int roomId)
        {
            RoomsDTO room = (from rooms
                             in _context.Rooms
                             where rooms.id == roomId
                             select new RoomsDTO
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
                             }).FirstOrDefault();
            return room;
        }
    }
}