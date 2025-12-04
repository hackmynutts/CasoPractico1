using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Rooms.RoomsList
{
    public class RoomsList_DA : IRoomsList_DA
    {
        private Context _context;
        public RoomsList_DA()
        {
            _context = new Context();
        }

        public List<RoomsDTO> GetRooms()
        {
            List<RoomsDTO> roomsList = (from rooms
                                     in _context.Rooms
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
                                        }).ToList();
            return roomsList;
        }

        public List<RoomsDTO> GetRoomsActivos()
        {
            List<RoomsDTO> roomsList = (from rooms
                                     in _context.Rooms
                                        where rooms.estado == true
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
                                        }).ToList();
            return roomsList;
        }
    }
}