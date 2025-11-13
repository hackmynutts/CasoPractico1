using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.DataAccess.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.DataAccess.Rooms.GetRoom;
using MiPrimeraSolucion.BusinessLogic.General.DateManagement;
using MyFirstSolution.Abstractions.General.DateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.BusinessLogic.Reservations.AddReservation
{
    public class AddReservation_BL : IAddReservation_BL
    {
        private readonly IAddReservation_DA _addReservationDA;
        private readonly Idate _date;
        private readonly IGetRoom_DA _getRoomDA;
        private readonly IEditRoom_DA _editRoomDA;
        public AddReservation_BL()
        {
            _addReservationDA = new AddReservation_DA();
            _date = new date();
            _getRoomDA = new GetRoom_DA();
            _editRoomDA = new EditRoom_DA();
        }

        public async Task<int> AddReserve(ReservationsDTO reservation2Add)
        {
            RoomsDTO room = _getRoomDA.GetRoomID(reservation2Add.idRoom);
            int cantDias = (reservation2Add.fechaFinReserva - reservation2Add.fechaInicioReserva).Days;
            reservation2Add.createdAt = _date.GetDate();
            reservation2Add.monto = (room.roomFee* cantDias) +room.cleaningFee;
            int reservationAdded = await _addReservationDA.AddReservation(reservation2Add);

            if (reservationAdded > 0)
            {
                room.estado = false;
                int rowsAffected = await _editRoomDA.EditRoom(room);
                
                if (rowsAffected <= 0)
                {
                    // Forzamos rollback
                    throw new Exception("No se pudo actualizar el estado de la habitación a no disponible.");
                }
            }
            return reservationAdded;
        }
    }
}