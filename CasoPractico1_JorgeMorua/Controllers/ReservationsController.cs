using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.EditReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.GetReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.ReservationsList;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.RoomsList;
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
        private IGetRoom_BL _getRoomIDBL;
        private IRoomsList_BL roomsList_BL;
        private IReservationList_BL _reservationListBL;
        private IGetReservation_BL _getReservationsBL;
        private IAddReservation_BL _addReservationBL;
        private IEditReservation_BL _editReservationBL;

        public ReservationsController()
        {
            _getRoomIDBL = new GetRoom_BL();
            roomsList_BL = new RoomsList_BL();
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

        [HttpGet]
        public JsonResult CalcularMonto(int roomId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaFin <= fechaInicio)
                {
                    return Json(new
                    {
                        success = false,
                        message = "La fecha de fin debe ser mayor que la de inicio."
                    }, JsonRequestBehavior.AllowGet);
                }

                RoomsDTO room = _getRoomIDBL.GetRoomID(roomId);
                if (room == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "No se encontró la habitación seleccionada."
                    }, JsonRequestBehavior.AllowGet);
                }

                // cantidad de días
                double dias = (fechaFin - fechaInicio).TotalDays;
                if (dias < 1) dias = 1; // por si acaso

                //calcular monto
                decimal monto = (decimal)dias * (room.roomFee + room.cleaningFee);

                return Json(new
                {
                    success = true,
                    total = monto
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error al calcular el monto: " + ex.GetBaseException().Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> CreatePV()
        {
            ReservationsDTO model = new ReservationsDTO();

            List<RoomsDTO> rooms = roomsList_BL.GetRoomsActivos();

            ViewBag.RoomsList = rooms.Select(r => new SelectListItem
            {
                Value = r.id.ToString(),
                Text = $"{r.codigo} - {r.nombre}"
            }).ToList();

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePV(ReservationsDTO reserve)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<RoomsDTO> rooms = roomsList_BL.GetRooms();

                    ViewBag.RoomsList = rooms.Select(r => new SelectListItem
                    {
                        Value = r.id.ToString(),
                        Text = $"{r.codigo} - {r.nombre}"
                    }).ToList();

                    if (Request.IsAjaxRequest())
                        return PartialView(reserve);

                    return PartialView(reserve);
                }

                int insertedReservation = await _addReservationBL.AddReserve(reserve);

                if (insertedReservation > 0)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, reservationId = insertedReservation });

                    return RedirectToAction("ReservationsList");
                }

                // ⬇️ SI LLEGA AQUÍ, EL INSERT FALLÓ
                ModelState.AddModelError("", "No se pudo insertar la reserva.");

                // VOLVEMOS A LLENAR RoomsList ANTES DE DEVOLVER LA VISTA
                List<RoomsDTO> roomsError = roomsList_BL.GetRooms();
                ViewBag.RoomsList = roomsError.Select(r => new SelectListItem
                {
                    Value = r.id.ToString(),
                    Text = $"{r.codigo} - {r.nombre}"
                }).ToList();

                if (Request.IsAjaxRequest())
                    return PartialView(reserve);

                return PartialView(reserve);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al insertar: " + ex.GetBaseException().Message);

                List<RoomsDTO> rooms = roomsList_BL.GetRooms();

                ViewBag.RoomsList = rooms.Select(r => new SelectListItem
                {
                    Value = r.id.ToString(),
                    Text = $"{r.codigo} - {r.nombre}"
                }).ToList();

                if (Request.IsAjaxRequest())
                    return Json(new { success = false, error = ex.GetBaseException().Message });

                return PartialView(reserve);
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
