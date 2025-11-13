using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.DataAccess.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess.Reservations.AddReservation
{
    public class AddReservation_DA : IAddReservation_DA
    {
        private Context _context;
        public AddReservation_DA() 
        {
            _context = new Context();
        }

        public async Task<int> AddReservation (ReservationsDTO reservationToAdd)
        {
            try 
            {
                ReservationsDA newReserve = Convert2DA(reservationToAdd);
                _context.Reservations.Add(newReserve);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Fallo al insertar: " + ex.GetBaseException().Message, ex);
            }
        }

        private ReservationsDA Convert2DA(ReservationsDTO reservation2Convert)
        {
            return new ReservationsDA
            {
                id = reservation2Convert.id,
                nombrePersona = reservation2Convert.nombrePersona,
                identificacion = reservation2Convert.identificacion,
                cel = reservation2Convert.cel,
                email = reservation2Convert.email,
                fechaNacimiento = reservation2Convert.fechaNacimiento,
                address = reservation2Convert.address,
                monto = reservation2Convert.monto,
                fechaInicioReserva = reservation2Convert.fechaInicioReserva,
                fechaFinReserva = reservation2Convert.fechaFinReserva,
                createdAt = reservation2Convert.createdAt,
                idRoom = reservation2Convert.idRoom
            };
        }
    }
}