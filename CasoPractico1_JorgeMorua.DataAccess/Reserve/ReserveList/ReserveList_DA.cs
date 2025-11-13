using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reserve.ReserveList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reserve.ReserveList
{
    public class ReserveList_DA : IReserveList_DA
    {
        private Context _context;
        public ReserveList_DA()
        {
            _context = new Context();
        }

        public List<RoomsDTO> GetReserveList()
        {
            List<RoomsDTO> availableRooms = (from rooms
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
                                                 roomType = rooms.roomType
                                             }).ToList();
            return availableRooms;
        }
    }
}