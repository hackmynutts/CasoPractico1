using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.ReservationsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CasoPractico1_JorgeMorua.Controllers
{
    public class ReservationsController : Controller
    {
        private IReservationList_BL _reservationListBL;
        private IGetReservation_BL _getReservationsBL;
        private IAddReservation_BL _addReservationBL;
        private IEditReservation_BL _editReservationBL;

        public ReservationsController()
        {
            _reservationListBL = new ReservationList_BL();
            _getReservationsBL = new GetReservation_BL();
            _addReservationBL = new AddReservation_BL();
            _editReservationBL = new EditReservation_BL();
        }
        // GET: Reservations
        public ActionResult ReservationsList()
        {
            List<ReservationsDTO> reservations = _reservationListBL.GetReservations();
            return View(reservations);
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            ReservationsDTO reservation = _getReservationsBL.GetReservation(id);
            if (reservation == null)
            {
                return HttpNotFound("No existe la reservación solicitada.");
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        public async Task<ActionResult> Create(ReservationsDTO reserve)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reserve);
                }

                int insertedReservation = await _addReservationBL.AddReserve(reserve);
                if (insertedReservation > 0) return RedirectToAction("ReservationsList");

                ModelState.AddModelError("", "No se pudo insertar la reserva.");
                return View(reserve);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al insertar: " + ex.GetBaseException().Message);
                return View(reserve);
            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            ReservationsDTO reserva = _getReservationsBL.GetReservation(id);
            return View(reserva);
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit( ReservationsDTO reservation)
        {
            try
            {
                // TODO: Add update logic here
                int editedLines = await _editReservationBL.EditReservation(reservation);
                if (editedLines > 0)
                {
                    return RedirectToAction("ReservationsList");
                }
                ModelState.AddModelError("", "No se pudo editar la reserva.");
                return View(reservation);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.GetBaseException().Message);
                return View(reservation);
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ReservationsList");
            }
            catch
            {
                return View();
            }
        }
    }
}
